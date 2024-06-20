(function () {
    "use strict";
    app.controller("AccountManagementCtrl", AccountManagementCtrl);
    AccountManagementCtrl.$inject = [
        "wbxChangePasswordService",
        "$scope",
        "API",
        "$location",
        "$window",
        "$q",
        "wbxListErrorsService",
        "DataService",
        "ImpersonateService",
        "$timeout",
        "GoogleTagManagerService",
    ];

    function AccountManagementCtrl(
        wbxChangePasswordService,
        $scope,
        API,
        $location,
        $window,
        $q,
        wbxListErrorsService,
        DataService,
        impersonateService,
        $timeout,
        googleTagManagerService
    ) {
        const ENROLLEE_SUPPLEMENTAL_NAME = "Survey Agreement";
        var vm = this;
        vm.UserDetails = {};
        vm.securityMaskDetails = {};
        vm.commPreferences = {};
        vm.PasswordInfo = {
            USER_NAME: "",
            NEW_PASSWORD: "",
            CONFIRM_PASSWORD: "",
            RESETPASS_VID: "",
        };
        vm.isImpersonation = DataService.IsImpersonation;
        vm.isCommPreferencesEnabled = DataService.IsCommPreferencesEnabled;
        vm.receiveSurveyOptions = DataService.ReceiveSurveyOptions;
        vm.enrolleeSupplemental = {};
        vm.receiveSurvey = "";
        vm.isAuthenticatorAppVerified = DataService.IsAuthenticatorAppVerified;
        vm.is2FAAuthenticatorAppEnabled =
            DataService.Is2FAAuthenticatorAppEnabled;

        vm.init = function (accountManagementData) {
            googleTagManagerService.setPageInfo("Account Management");
            vm.AccountManagementData = accountManagementData;
            vm.isMFAEnabled = DataService.IsMFAEnabled;
            vm.isSmsOn = DataService.IsSmsOn;

            if (vm.AccountManagementData) {
                vm.UserDetails.USER_NAME = vm.AccountManagementData.USER_NAME;
                vm.UserDetails.FIRST_NAME = vm.AccountManagementData.FIRST_NAME;
                vm.UserDetails.MIDDLE_NAME =
                    vm.AccountManagementData.MIDDLE_NAME;
                vm.UserDetails.LAST_NAME = vm.AccountManagementData.LAST_NAME;
                vm.UserDetails.EMAIL = vm.AccountManagementData.EMAIL;
                vm.EditPersonalInformationFlag =
                    vm.AccountManagementData.EditPersonalInformationFlag;
            }
            vm.getuserData();
            vm.navigateToTab();
            if (DataService.IsCommPreferencesEnabled) {
                vm.showCommPreferencesUpdated = false;
                vm.showCommPreferencesUpdateFailed = false;
                getCommPreferences();
            }

            if (DataService.IsOfferSurveysEnabled) {
                vm.showCommPreferencesUpdated = false;
                vm.showCommPreferencesUpdateFailed = false;
                getOfferSurveySettings();
            }
            impersonateService
                .getImpersonateSessionInfo()
                .then(function (response) {
                    vm.isImpersonation = response.IsImpersonation;
                });
        };

        vm.removeAuthAcctModal = function () {
            $("#removeAuthAcctModal").modal("show");
        };

        vm.firstTime2fa = function () {
            API.post("/Account/RelinkAuthenticatorApp").then(function () {
                window.location.href = "/FirstTime2fa/Index";
            });
        };

        vm.navigateToTab = function () {
            var tab = $location.path();
            if (tab != "") {
                tab = tab.replace("/", "");
                $('#AccountManagementTab a[href="#' + tab + '"]').tab("show");
            }
        };

        vm.getuserData = function () {
            API.get("/MultiFactor/GetUserData").then(function (response) {
                vm.securityMaskDetails = response.data;
            });
        };

        var getCommPreferences = function () {
            API.get("/AccountManagement/GetCommPreferences").then(function (
                response
            ) {
                vm.commPreferences = response;
            });
        };
        var getOfferSurveySettings = function () {
            API.get("/AccountManagement/GetOfferSurveySettings").then(function (
                response
            ) {
                if (response === null || response.length === 0) return;
                vm.enrolleeSupplemental = response;
                vm.receiveSurvey =
                    vm.enrolleeSupplemental.keys[ENROLLEE_SUPPLEMENTAL_NAME];
            });
        };

        vm.validateForm = function () {
            $timeout(function () {
                vm.errors = wbxListErrorsService.getErrorListForBanner(
                    vm.profile_form
                );
            }, 0);
        };

        vm.updateProfile = function () {
            if (!vm.isImpersonation) {
                var deferred = $q.defer();
                if (vm.profile_form.$invalid) {
                    vm.errors = wbxListErrorsService.getErrorListForBanner(
                        vm.profile_form
                    );
                    return false;
                }
                API.put("/AccountManagement/UpdateProfile", {
                    FIRST_NAME: vm.UserDetails.FIRST_NAME,
                    MIDDLE_NAME: vm.UserDetails.MIDDLE_NAME,
                    LAST_NAME: vm.UserDetails.LAST_NAME,
                    EMAIL: vm.UserDetails.EMAIL,
                }).then(
                    function (response) {
                        if (!response.error) {
                            deferred.resolve(true);
                            vm.showPersonalInfoUpdated = true;
                            vm.getuserData();
                            vm.profile_form.$setPristine();
                        } else {
                            deferred.reject(response);
                        }
                    },
                    function (failed) {
                        deferred.reject(failed);
                    }
                );

                return deferred.promise;
            }
        };

        $scope.$watch("vm.profile_form.$pristine", function (n, o) {
            if (n != o && !n) {
                vm.showPersonalInfoUpdated = false;
            }
        });

        // End personal info

        //Password change
        //wbx-change-password-component
        $scope.$watch("isPasswordValid", function (n, o) {
            if (n != o) {
                vm.password_form.NewPasswordTextBox.$setValidity(
                    "notvalid",
                    vm.isPasswordValid
                );
            }
        });

        //End password change

        vm.changeSecurity = function () {
            if (!vm.isImpersonation) {
                window.location =
                    "/AccountManagement/VerifyYourIdentity?accountManagement=1";
            }
        };

        vm.updateCommPreferences = function () {
            if (!vm.isImpersonation) {
                var deferred = $q.defer();
                if (vm.comm_preferences_form.$invalid) {
                    vm.errors = "Invalid communication type";
                    return false;
                }

                API.put("/AccountManagement/UpdateCommunicationPreferences", {
                    EOB_COMMUNICATION_METHOD:
                        vm.commPreferences.EOB_COMMUNICATION_METHOD,
                    ID_CARD_COMMUNICATION_METHOD:
                        vm.commPreferences.ID_CARD_COMMUNICATION_METHOD,
                    LETTER_COMMUNICATION_METHOD:
                        vm.commPreferences.LETTER_COMMUNICATION_METHOD,
                    APPLY_TO_ALL_MEMBERS:
                        vm.commPreferences.APPLY_TO_ALL_MEMBERS,
                    RECEIVE_SURVEY: vm.receiveSurvey,
                }).then(
                    function (response) {
                        if (!response.error) {
                            deferred.resolve(true);
                            vm.showCommPreferencesUpdated = true;
                            vm.showCommPreferencesUpdateFailed = false;
                        } else {
                            vm.showCommPreferencesUpdated = false;
                            vm.showCommPreferencesUpdateFailed = true;
                            deferred.reject(response);
                        }
                    },
                    function (failed) {
                        deferred.reject(failed);
                    }
                );

                return deferred.promise;
            }
        };

        vm.routeToEConsent = function () {
            if (!vm.isImpersonation) {
                API.post("/AccountManagement/GetEConsentRouting").then(
                    function (response) {
                        $window.location.href = response;
                    }
                );
            }
        };
    }
})();