<template>
     <div class="card">
        <div class="card-header">
            <h5>Verticle Wizard</h5>
            <span>Add class of <code>.form-control</code> with <code>&lt;input&gt;</code> tag</span>
        </div>
    <div class="card-block">
        <div class="row">
            <div class="col-md-12">
                <div id="wizardb">
                    <section>
                        <form class="wizard-form" id="verticle-wizard" action="#">
                            <h3> Registration </h3>
                            <fieldset>
                                <div class="form-group row">
                                    <div class="col-sm-12">
                                        <label for="userName-2" class="block">User name *</label>
                                    </div>
                                    <div class="col-sm-12">
                                        <input id="userName-2b" name="userName" type="text" class=" form-control">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-12">
                                        <label for="email-2" class="block">Email *</label>
                                    </div>
                                    <div class="col-sm-12">
                                        <input id="email-2b" name="email" type="email" class=" form-control">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-12">
                                        <label for="password-2" class="block">Password *</label>
                                    </div>
                                    <div class="col-sm-12">
                                        <input id="password-2b" name="password" type="password" class="form-control ">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-12">
                                        <label for="confirm-2" class="block">Confirm Password *</label>
                                    </div>
                                    <div class="col-sm-12">
                                        <input id="confirm-2b" name="confirm" type="password" class="form-control ">
                                    </div>
                                </div>
                            </fieldset>
                            <h3> General information </h3>
                            <fieldset>
                                <div class="form-group row">
                                    <div class="col-sm-12">
                                        <label for="name-2" class="block">First name *</label>
                                    </div>
                                    <div class="col-sm-12">
                                        <input id="name-2b" name="name" type="text" class="form-control">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-12">
                                        <label for="surname-2" class="block">Last name *</label>
                                    </div>
                                    <div class="col-sm-12">
                                        <input id="surname-2b" name="surname" type="text" class="form-control">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-12">
                                        <label for="phone-2" class="block">Phone #</label>
                                    </div>
                                    <div class="col-sm-12">
                                        <input id="phone-2b" name="phone" type="number" class="form-control phone">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-12">
                                        <label for="date" class="block">Date Of Birth</label>
                                    </div>
                                    <div class="col-sm-12">
                                        <input id="dateb" name="Date Of Birth" type="text" class="form-control date-control">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-12">Select Country</div>
                                    <div class="col-sm-12">
                                        <select class="form-control required">
                                                <option>Select State</option>
                                                <option>Gujarat</option>
                                                <option>Kerala</option>
                                                <option>Manipur</option>
                                                <option>Tripura</option>
                                                <option>Sikkim</option>
                                            </select>
                                    </div>
                                </div>
                            </fieldset>
                            <h3> Education </h3>
                            <fieldset>
                                <div class="form-group row">
                                    <div class="col-sm-12">
                                        <label for="University-2" class="block">University</label>
                                    </div>
                                    <div class="col-sm-12">
                                        <input id="University-2b" name="University" type="text" class="form-control required">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-12">
                                        <label for="Country-2" class="block">Country</label>
                                    </div>
                                    <div class="col-sm-12">
                                        <input id="Country-2b" name="Country" type="text" class="form-control required">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-12">
                                        <label for="Degreelevel-2" class="block">Degree level #</label>
                                    </div>
                                    <div class="col-sm-12">
                                        <input id="Degreelevel-2b" name="Degree level" type="text" class="form-control required phone">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-12">
                                        <label for="datejoin" class="block">Date Join</label>
                                    </div>
                                    <div class="col-sm-12">
                                        <input id="datejoinb" name="Date Of Birth" type="text" class="form-control required">
                                    </div>
                                </div>
                            </fieldset>
                            <h3> Work experience </h3>
                            <fieldset>
                                <div class="form-group row">
                                    <div class="col-sm-12">
                                        <label for="Company-2" class="block">Company:</label>
                                    </div>
                                    <div class="col-sm-12">
                                        <input id="Company-2b" name="Company:" type="text" class="form-control required">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-12">
                                        <label for="CountryW-2" class="block">Country</label>
                                    </div>
                                    <div class="col-sm-12">
                                        <input id="CountryW-2b" name="Country" type="text" class="form-control required">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-12">
                                        <label for="Position-2" class="block">Position</label>
                                    </div>
                                    <div class="col-sm-12">
                                        <input id="Position-2b" name="Position" type="text" class="form-control required">
                                    </div>
                                </div>
                            </fieldset>
                        </form>
                    </section>
                </div>
            </div>
        </div>
    </div>
</div>
</template>

                                               
