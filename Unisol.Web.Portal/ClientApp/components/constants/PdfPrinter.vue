<script>
import pdfMake from 'pdfmake/build/pdfmake';
import pdfFonts from 'pdfmake/build/vfs_fonts';
import EndPoints from './EndPoints';
pdfMake.vfs = pdfFonts.pdfMake.vfs;
export default {
  printPdf: function(tableData, detailsObject) {
    var userDetails = detailsObject.userDetails;
    var userLoans = detailsObject.userLoans;
    var institutionInfo = JSON.parse(localStorage.getItem('institutionInfo'));
    var settings = JSON.parse(localStorage.getItem('settings'));
    var docStyles = {
      header: {
        fontSize: 14,
        bold: true
      },

      subHeader: {
        fontSize: 10,
        bold: true
      },

      content: {
        fontSize: 8,
        bold: false
      },
      paddedTable: {
        fontSize: 9,
        margin: [0, 2, 0, 2],
        bold: false
      },
      sectionHeader: {
        fontSize: 12,
        margin: [0, 4, 0, 4],
        bold: true
      },
      numeric: {
        alignment: 'right',
        fontSize: 9,
        bold: false
      },
      feeHeader: {
        alignment: 'right',
        fontSize: 9,
        bold: true
      },
      centerData: {
        alignment: 'center'
      },
      alignLeft: {
        alignment: 'left'
      },
      alignRight: {
        float: 'right'
      }
    };

    var getDataUrl = function readImage() {
      return false;
    };
    var imageLogo = {
      image: settings.logoDataUrl,
      width: 80,
      height: 80,
      style: ['centerData'],
      margin: [0, 0, 0, 0],
      padding: [0, 0, 0, 0]
    };

    if(settings.initials == "LU"){
      imageLogo = {
        image: settings.logoDataUrl,
        width: 250,
        height: 100,
        style: ['centerData'],
        margin: [0, 0, 0, 0],
        padding: [0, 0, 0, 0]
      }
    }

    var headerDetails = []
    institutionInfo.contactArray.forEach(element => {
      var detail = [
        { text: element, style: ['content', 'centerData'] }
      ] 
      headerDetails.push(detail)
    })

    var docDefinition = {
      styles: docStyles,
      //header: 'simple text',
      pageOrientation: detailsObject.pageOrientation,
      content: [
        detailsObject.timeStamp,
        // {
        //   stack: ["a stack", "of", "unbreakable", "paragraphs"],
        //   unbreakable: true
        // },
        imageLogo,
        {
          text: institutionInfo.setting.orgName.toUpperCase(),
          style: ['header', 'centerData']
        },
        headerDetails,
        detailsObject.registererLabel,
        {
          text: detailsObject.reportHeader,
          style: ['subHeader', 'centerData'],
          margin: [0, 5, 0, 0]
        },

        // {text:"Google", link:"http://www.google.com", decoration:"underline",fillColor: 'blue', margin: [0, 5, 0, 0]},
        {
          text:
            '_____________________________________________________________________________________________',
          margin: [0, 0, 0, 5]
        },
        { text: detailsObject.username},
        {
          table: {
            widths: detailsObject.tableWidth,
            body: [
              [
                { text: detailsObject.nationalId },
                { text: detailsObject.pinNo }
              ],
              [{text: detailsObject.department}, {text: detailsObject.nhif}]
            ]
          },
          layout: {
            hLineWidth: function(i, node) {
              return i === 0 || i === node.table.body.length
                ? 0.0
                : detailsObject.lineWidth;
            },
            vLineWidth: function(i, node) {
              return i === 0 || i === node.table.widths.length ? 0.0 : 0.0;
            },
            hLineColor: function(i, node) {
              return i === 0 || i === node.table.body.length
                ? 'black'
                : 'black';
            },
            vLineColor: function(i, node) {
              return i === 0 || i === node.table.widths.length
                ? 'black'
                : 'black';
            },
            paddingLeft: function(i, node) {
              return 4;
            },
            paddingRight: function(i, node) {
              return 4;
            },
            paddingTop: function(i, node) {
              return 2;
            },
            paddingBottom: function(i, node) {
              return 2;
            }
          }
        },
        { text: detailsObject.department, style: ['alignLeft'] },
        { text: detailsObject.jobTitle, style: ['alignLeft'] },
        { text: detailsObject.pgrade, style: ['alignLeft'] },
        detailsObject.usercode,
        detailsObject.rDate,
        detailsObject.bank,
        detailsObject.jobTitle,
        detailsObject.nhif,
        detailsObject.nssf,
        detailsObject.school,
        detailsObject.Program,
        detailsObject.Class,
        detailsObject.admissionYear,
        detailsObject.Session,
        detailsObject.SerialNo,
        detailsObject.loanDescription,
        detailsObject.debtorName,
        detailsObject.userInfoTableObj,
        detailsObject.underline,
        {
          table: {
            headerRows: 1,
            widths: detailsObject.tableWidth,
            unbreakable: true,
            body: tableData
          },
          layout: {
            hLineWidth: function(i, node) {
              return i === 0 || i === node.table.body.length
                ? 0.0
                : detailsObject.lineWidth;
            },
            vLineWidth: function(i, node) {
              return i === 0 || i === node.table.widths.length ? 0.0 : 0.0;
            },
            hLineColor: function(i, node) {
              return i === 0 || i === node.table.body.length
                ? 'black'
                : 'black';
            },
            vLineColor: function(i, node) {
              return i === 0 || i === node.table.widths.length
                ? 'black'
                : 'black';
            },
            paddingLeft: function(i, node) {
              return 4;
            },
            paddingRight: function(i, node) {
              return 4;
            },
            paddingTop: function(i, node) {
              return 2;
            },
            paddingBottom: function(i, node) {
              return 2;
            }
          }
        },
        detailsObject.underline,
        detailsObject.netPayableObj,
        detailsObject.netPayableWords,
        {
          text:
            '_______________________________________________________________________________________________',
          margin: [0, 0, 0, 2]
        },

        detailsObject.average,
        detailsObject.recommendation,
        detailsObject.infoTable,
        detailsObject.registrarSign,
        detailsObject.signature,
        detailsObject.stamp,
        detailsObject.signature,
        detailsObject.notes,
        detailsObject.notesContent,
        detailsObject.departmentSignature,
        detailsObject.transcriptNote
      ],

      pageBreakBefore: function(currentNode, followingNodesOnPage, nodesOnNextPage, previousNodesOnPage) {
        return currentNode.headlineLevel === 1 && followingNodesOnPage.length === 0;
      },

      footer: function(page, pages) {
        return {
          columns: [
            // {
            //   text: institutionInfo.setting.orgName,
            //   style: ['content']
            // },
            // {
            //   alignment: 'right',
            //   text: [
            //     { text: 'Page: ' + page.toString(), style: ['content'] },
            //     { text: ' of ', italics: true, style: ['content'] },
            //     { text: pages.toString(), style: ['content'] }
            //   ]
            // }
          ],
          margin: [40, 10, 40, 0]
        };
      }
    };

    pdfMake.createPdf(docDefinition).download(detailsObject.fileName + '.pdf');
  },
  printPaySlip: function(tableData, detailsObject) {
    var userDetails = detailsObject.userDetails;
    var userLoans = detailsObject.userLoans;
    var institutionInfo = JSON.parse(localStorage.getItem('institutionInfo'));
    var settings = JSON.parse(localStorage.getItem('settings'));
    var docStyles = {
      header: {
        fontSize: 14,
        bold: true
      },

      subHeader: {
        fontSize: 10,
        bold: true
      },

      content: {
        fontSize: 8,
        bold: false
      },
      paddedTable: {
        fontSize: 9,
        margin: [0, 2, 0, 2],
        bold: false
      },
      sectionHeader: {
        fontSize: 12,
        margin: [0, 4, 0, 4],
        bold: true
      },
      tableHeader: {
        fontSize: 9,
        bold: false
      },
      centerData: {
        alignment: 'center'
      },
      alignLeft: {
        alignment: 'left'
      },
      alignRight: {
        float: 'right'
      }
    };

    var getDataUrl = function readImage() {
      return false;
    };

    var imageLogo = {
      image: settings.logoDataUrl,
      width: 80,
      height: 80,
      style: ['centerData'],
      margin: [0, 0, 0, 0],
      padding: [0, 0, 0, 0]
    };

    if(settings.initials == "LU"){
      imageLogo = {
        image: settings.logoDataUrl,
        width: 250,
        height: 100,
        style: ['centerData'],
        margin: [0, 0, 0, 0],
        padding: [0, 0, 0, 0]
      }
    }

    var headerDetails = []
    institutionInfo.contactArray.forEach(element => {
      var detail = [
        { text: element, style: ['content', 'centerData'] }
      ] 
      headerDetails.push(detail)
    })

    var docDefinition = {
      styles: docStyles,
      pageOrientation: detailsObject.pageOrientation,
      content: [
        detailsObject.timeStamp,
        imageLogo,
        {
          text: institutionInfo.setting.orgName.toUpperCase(),
          style: ['header', 'centerData']
        },
        headerDetails,
        {
          text: detailsObject.reportHeader,
          style: ['subHeader', 'centerData'],
          margin: [0, 5, 0, 0]
        },
        {
          text:
            '_____________________________________________________________________________________________',
          margin: [0, 0, 0, 5]
        },
        { text: detailsObject.username, style: ['content', 'centerData'] },
        {
          table: {
            widths: detailsObject.tableWidth,
            body: detailsObject.pSlipHeader
          },
          layout: {
            hLineWidth: function(i, node) {
              return i === 0 || i === node.table.body.length
                ? 0.0
                : detailsObject.lineWidth;
            },
            vLineWidth: function(i, node) {
              return i === 0 || i === node.table.widths.length ? 0.0 : 0.0;
            },
            hLineColor: function(i, node) {
              return i === 0 || i === node.table.body.length
                ? 'black'
                : 'black';
            },
            vLineColor: function(i, node) {
              return i === 0 || i === node.table.widths.length
                ? 'black'
                : 'black';
            },
            paddingLeft: function(i, node) {
              return 4;
            },
            paddingRight: function(i, node) {
              return 4;
            },
            paddingTop: function(i, node) {
              return 2;
            },
            paddingBottom: function(i, node) {
              return 2;
            }
          }
        },
        detailsObject.usercode,
        detailsObject.Program,
        detailsObject.Class,
        detailsObject.Session,
        detailsObject.SerialNo,
        detailsObject.loanDescription,
        detailsObject.debtorName,
        detailsObject.userInfoTableObj,
        detailsObject.underline,
        {
          table: {
            headerRows: 1,
            // pageOrientation: 'landscape',
            widths: detailsObject.tableWidth,
            body: tableData
          },
          layout: {
            hLineWidth: function(i, node) {
              return i === 0 || i === node.table.body.length
                ? 0.0
                : detailsObject.lineWidth;
            },
            vLineWidth: function(i, node) {
              return i === 0 || i === node.table.widths.length ? 0.0 : 0.0;
            },
            hLineColor: function(i, node) {
              return i === 0 || i === node.table.body.length
                ? 'black'
                : 'black';
            },
            vLineColor: function(i, node) {
              return i === 0 || i === node.table.widths.length
                ? 'black'
                : 'black';
            },
            paddingLeft: function(i, node) {
              return 4;
            },
            paddingRight: function(i, node) {
              return 4;
            },
            paddingTop: function(i, node) {
              return 2;
            },
            paddingBottom: function(i, node) {
              return 2;
            }
          }
        },
        detailsObject.underline,
        detailsObject.netPayableObj,
        detailsObject.netPayableWords,
        {
          text:
            '_______________________________________________________________________________________________',
          margin: [0, 0, 0, 2]
        },

        detailsObject.infoTable,
        detailsObject.registrarSign,
        detailsObject.signature,
        detailsObject.stamp,
        detailsObject.signature
      ],

      footer: function(page, pages) {
        return {
          columns: [
            {
              text: institutionInfo.setting.orgName,
              style: ['content']
            },
            {
              alignment: 'right',
              text: [
                { text: 'Page: ' + page.toString(), style: ['content'] },
                { text: ' of ', italics: true, style: ['content'] },
                { text: pages.toString(), style: ['content'] }
              ]
            }
          ],
          margin: [40, 10, 40, 0]
        };
      }
    };

    pdfMake.createPdf(docDefinition).download(detailsObject.fileName + '.pdf');
  }
};
</script>
