<template>
  <div class="page-body"><br>
    <div class="card">
      <div class="card-header">
        <h5>File Directory</h5>
      </div>
      <loading-spinner :loading="loading"></loading-spinner>
      <div class="card-block" v-if="!loading">
        <div class="row">
          <div class="col-md-5">
            <div v-if="!isStudentRepository">
              <div v-if="clickedFolderStatus">
                <logo-section :uploadUrl="fileUploadUrl" :url="folder.folderPath"></logo-section>
              </div>

              <button
                data-toggle="modal"
                data-target="#folderModal"
                class="btn btn-primary btn-round waves-effect waves-light btn-sm ml-1">
                <i class="fa fa-plus-circle"></i> New Folder
              </button>
              <button
                class="btn btn-primary btn-round waves-effect waves-light btn-sm ml-1"
                :disabled="!clickedFolderStatus"
                @click="editFolder"
              >
                <i class="fa fa-edit"></i> Edit Folder
              </button>
              <button
                class="btn btn-primary btn-round waves-effect waves-light btn-sm ml-1"
                :disabled="!clickedFolderStatus"
                @click="deleteFolder"
                v-if="user.role == 1">
                <i class="fa fa-trash"></i> Delete Folder
              </button>
              <button
                class="btn btn-primary btn-round waves-effect waves-light btn-sm ml-1"
                :disabled="!clickedFolderStatus"
                @click="publish"
                v-if="user.role == 1 && !published">
                <i class="fa fa-trash"></i> Activate
              </button>
              <br />
              <br />
            </div>

            <div class="modal fade" id="folderModal" role="dialog">
              <div class="modal-dialog modal-lg">
                <div class="modal-content">
                  <div class="modal-header text-left">
                    <div class="h5">Create {{subTitle}} Folders</div>
                  </div>

                  <div class="modal-body">
                    <form>
                      <div class="form-group">
                        <label for="folderName">Folder Name</label>
                        <input
                          v-model="folder.folderName"
                          type="text"
                          class="form-control"
                          id="folderName"
                          aria-describedby="emailHelp"
                          placeholder="Folder Name"
                        />
                      </div>
                      <div v-if="!clickedFolderStatus">
                        <p>Select Roles</p>
                        <div
                          class="form-check form-check-inline"
                          v-for="(role,ind) in roles"
                          :key="ind"
                        >
                          <input
                            :id="role.name"
                            class="form-check-input"
                            v-model="folder.role"
                            type="radio"
                            @click="getUserGroups(role.value)"
                            :value="role.value"
                          />
                          <label :for="role.name" class="form-check-label">{{role.name}}</label>
                        </div>
                        <br />
                        <br />
                      </div>

                      <div v-if="!clickedFolderStatus">
                        <p>Select user Groups</p>
                        <div
                          class="form-check form-check-inline"
                          v-for="(group) in userGroups"
                          :key="group.groupName"
                        >
                          <input
                            class="form-check-input"
                            type="checkbox"
                            v-model="folder.userGroups"
                            :value="group.id"
                          />
                          <label class="form-check-label">{{group.groupName}}</label>
                        </div>
                      </div>
                    </form>
                  </div>

                  <div class="modal-footer">
                    <div class="pull-right">
                      <submit-button
                        :title="buttonText"
                        styling="btn btn-primary btn-round waves-effect waves-light btn-sm"
                        :loading="submitting"
                        v-on:submit="createFolder()"
                      ></submit-button>
                      <button
                        class="btn btn-inverse btn-round waves-effect waves-light btn-sm"
                        data-dismiss="modal"
                      >Cancel</button>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <div
              v-if="parentFolderPresent && !isPreview"
              style="width:49%; display:inline-block; vertical-align: top;">
            <v-jstree
              :data="dataToLoad"
              :async="asyncData"
              whole-row
              @item-click="getSubFolder"
              ref="tree2"
            ></v-jstree>
            </div>

            <div v-if="isPreview">
              <img :src="fileUploadUrl" width="100%">
            </div>
          </div>
          <div class="col-md-7" v-if="parentFolderPresent && clickedFolderStatus">
            <data-table
              v-if="!gettingFiles"
              :data="filesInFolder"
              :columns="columns"
              :tableActions="tableActions"
              :headerActions="headerActions"
              :subTitle="subTitle"
              :title="title"
              :pagination="pagination"
              v-on:buttonEvent="buttonEvent"
              v-on:searchByText="searchByText"
            ></data-table>
          </div>
        </div>
        <div class="row">
          <loading-spinner :loading="gettingFiles"></loading-spinner>
          <div class="col-md-12">
            <div v-if="!parentFolderPresent" class="alert alert-info">
              <i class="fa fa-exclamation-circle fa-2x"></i>
              {{displayMessage}}
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import LogoSection from "./File";
import DateFomatter from "../../components/constants/DateFomatter";
import { EventBus } from "../../app.js";
import END_POINTS from "../../components/constants/EndPoints";

//import jsPDF from 'jsPDF'
export default {
  components: {
    LogoSection
  },

  mounted() {
    EventBus.$on("fileUpload", clickCount => {
      this.reloadAftrerSave(this.clickedNode);
    });
  },

  props: ["uploadStatus"],
  data() {
    return {
      clickCount: 0,
      dataToLoad: [],
      data: [],
      subRepository: [],
      isPreview: false,
      subTitle: "",
      searchText: "",
      loading: false,
      parentFolderPresent: false,
      displayMessage: "",
      isStudentRepository: false,
      gettingFiles: false,
      submitting: false,
      clickedFolderStatus: false,
      published: false,
      filesInFolder: [],
      buttonText: "Save",
      roles: [],
      clickedNode: {},
      fileUploadUrl: "",
      userGroups: [],
      title: "Files",
      folder: {
        isParent: true,
        parentId: 0,
        userGroups: []
      },
      tableActions: [],
      headerActions: [],
      columns: [
        {
          name: "File Name",
          type: "currency"
        },
        {
          name: "Date Added",
          type: "code"
        },
        {
          name: "Size",
          type: "numeric"
        },
        {
          name: "Status",
          type: "numeric"
        }
      ],
      pagination: {
        total: 0
      }
    };
  },
  created() {
    this.user = this.$baseRead("user");
    this.roles = END_POINTS.ROLES(this.user);
    this.getTableActions();
    this.loadData();
    //this.getSystemRoles();
  },
  methods: {
    searchByText(enteredText) {
      this.searchText = enteredText;
      this.getFilesInFolder(this.folder.parentId);
    },
    stripContent(content) {
      let regex = /(<([^>]+)>)/ig
      return content.replace(regex, "")
    },
    asyncData(oriNode, resolve) {
      var id = oriNode.data.id ? oriNode.data.id : 0;
      let data = [];
      if (id < 1) {
        data = this.data;
        resolve(data);
      } else {
        this.getSubFolder(oriNode);
        setTimeout(() => {
          data = this.data;
          resolve(data);
        }, 2000);
      }
    },
    getTableActions(){
      this.tableActions = [
         {
          name: "Download",
          type: "button",
          path: "download",
          design: "primary"
        },
        // {
        //   name: "Preview",
        //   type: "button",
        //   path: "preview",
        //   design: "primary"
        // },
        {
          name: "Publish",
          type: "button",
          path: "publish",
          design: "primary"
        },
        {
          name: "Delete",
          type: "button",
          path: "delete",
          design: "primary"
        }
      ]
      if(this.user.role != 1){
        this.tableActions = [
          {
            name: "Download",
            type: "button",
            path: "download",
            design: "primary"
          },
          // {
          //   name: "Preview",
          //   type: "button",
          //   path: "preview",
          //   design: "primary"
          // }
        ]
      }
    },
    loadData() {
      this.loading = true;
      if (this.user.role == 3) this.isStudentRepository = true;
      this.$http
        .get("repository/getParentFolders?usercode=" + this.user.username)
        .then(result => {
          if (result.data.success) {
            var info = result.data.data;
            info.forEach(element => {
              var status = element.parent.status ? "" : " - (Inactive)"
              var folderName = `${element.parent.folderName} ${status}`
              var parent = {
                id: element.parent.id,
                folderName: element.parent.folderName,
                folderPath: element.parent.folderPath,
                isParent: element.parent.isParent,
                parentId: element.parent.parentId,
                status: element.parent.status,
                opened: false,
                text: folderName
              };
              this.data.push(parent);

              if (this.data.length) this.parentFolderPresent = true;
            });
          } else {
            this.displayMessage = result.data.message;
          }
          this.loading = false;
        })
        .catch(error => {
          this.loading = false;
        });
    },
    reloadAftrerSave() {
      this.getSubFolder(this.clickedNode);
    },
    getSubFolder(node) {
      this.clickedNode = node;
      this.folder.parentId = node.model.id;
      this.published = node.model.status;
      this.folder.isParent = false;
      this.clickedFolderStatus = true;
      this.folder.folderPath = node.model.folderPath;
      this.fileUploadUrl = "repository/saveUploadedFiles?folderId=" + this.folder.parentId + "&usercode=" + this.user.username;
      this.subTitle = node.model.folderName;
      this.getFilesInFolder(this.folder.parentId);
      this.$http.get("repository/getParentSubFolders?parentId=" + this.folder.parentId + "&usercode=" + this.user.username)
        .then(result => {  
          var info = result.data.data;
          this.data = [];
          if (result.data.success) {
            info.forEach(element => {
              var status = element.parent.status ? "" : " - (Inactive)"
              var folderName = `${element.parent.folderName} ${status}`
              var subFolder = {
                id: element.parent.id,
                folderName: element.parent.folderName,
                folderPath: element.parent.folderPath,
                isParent: element.parent.isParent,
                parentId: element.parent.parentId,
                opened: false,
                text: folderName
              };
              this.data.push(subFolder);
            });
            this.folder.userGroups = info.parent.userGroups;
          } 
          else {
            info.forEach(element => {
              var subFolder = {
                id: element.parent.id,
                folderName: element.parent.folderName,
                folderPath: element.parent.folderPath,
                isParent: element.parent.isParent,
                parentId: element.parent.parentId,
                opened: false,
                text: element.parent.folderName
              };
              this.data.push(subFolder);
            });
            this.folder.userGroups = info;
          }
        })
        .catch(error => {});
    },
    getFilesInFolder(fid) {
      this.$http.get("repository/filesInFolder?folderId=" + fid + "&usercode=" + this.user.username + "&searchText="+ this.searchText)
        .then(result => {
          var info = result.data.data;
          this.filesInFolder = [];
          info.forEach(element => {
            var item = {
              id: element.id,
              filename: this.stripContent(element.fileName).substr(0,10) + '...',
              dateadded: DateFomatter.ReturnDate(element.dateAdded),
              size: (element.fileSize / 1024).toFixed(2) + "KBs",
              status: element.status ? "Active" : "Inactive",
              filePath: element.filePath
            };
            this.filesInFolder.push(item);
          });
          this.pagination.total = this.filesInFolder.length;
        })
        .catch(error => {
        });
    },
    createFolder() {
      this.submitting = true;
      this.folder.userGroups = this.folder.userGroups.toString();
      this.folder.createdBy = this.user.username
      this.$http
        .post("repository/createFolder", this.folder)
        .then(response => {
          if (response.data.success) {
            this.$toastr("success", "Folder created successfully");
            window.location.reload();
            this.clickedFolderStatus = false;
          } else {
            this.$toastr("error", response.data.message);
            this.clickedFolderStatus = false;
          }
          this.submitting = false;
          // this.$router.replace({ name: "repository" });
        })
        .catch(e => {
          this.$toastr("error", e.message);
          this.submitting = false;
          this.clickedFolderStatus = false;
        });
    },
    getSystemRoles() {
      this.$http
        .get("users/getRoles")
        .then(result => {
          this.roles = result.data.data;
        })
        .catch(error => {});
    },
    getUserGroups(role) {
      this.userGroups = [];
      this.folder.userGroups = [];
      this.$http
        .get("userGroups/pages?role=" + role)
        .then(result => {
          this.userGroups = result.data.data;
        })
        .catch(error => {});
    },
    buttonEvent(item, action) { 
      switch (action) {
        case "preview":
          this.isPreview = true
          this.fileUploadUrl = "/Documents/" + item.filePath
        break;

        case "download":
          this.isPreview = true
          var url = window.location.origin + "/Documents/" + item.filePath;
          window.open(url, "_blank");
        break;
        case "delete":
          this.$http
            .get("repository/DeleteFiles?fileId=" + item.id)
            .then(result => {
              this.$toastr("success", result.data.message);
              window.location.reload();
            })
            .catch(error => {
              this.loading = false;
            });
          break;
          case "publish":
          this.$http.get("repository/publishFiles?fileId=" + item.id)
            .then(result => {
              this.$toastr("success", result.data.message);
              window.location.reload();
            })
            .catch(error => {
              this.loading = false;
            });
          break;
        default:
          break;
      }
    },
    deleteFolder() {
      swal({
        title: "Are you sure?",
        text: "You can't revert your action"
      }).then(result => {
        var id = this.clickedNode.model.id;
        if (id != null) {
          this.$http
            .get("repository/DeleteFolder?folderId=" + id)
            .then(result => {
              window.location.reload();
            })
            .catch(error => {
              this.loading = false;
            });
        }
      });
    },
    publish(){
      var id = this.clickedNode.model.id;
      if (id != null) {
        this.$http.get("repository/publish?folderId=" + id)
        .then(result => {
          window.location.reload();
        })
        .catch(error => {
          this.loading = false;
        });
      }
    },
    editFolder() {
      this.$swal({
        title: "Edit Folder",
        input: "text",
        inputPlaceholder: "Enter New Folder Name",
        showCancelButton: true,
        showCloseButton: true,
        confirmButtonText: "Edit",
        cancelButtonText: "Cancel"
      }).then(result => {
        if (result.value) {
          var id = this.clickedNode.model.id;
          if (id != null) {
            this.$http.get(
                "repository/EditFolder?folderId=" + id + "&folderName=" + result.value + "&usercode=" + this.user.username
              ).then(result => {
                if(result.data.success){
                  location.reload();
                }
                else{
                  this.$toastr("error", result.data.message);
                }
              })
              .catch(error => {
                this.loading = false;
              });
          }
        } else {
        }
      });
    }
  }
};
</script>
<style>
</style>
