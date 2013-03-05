
$(document).ready(function () {


//        var oTable = $('#myDataTable').dataTable({
//        	"bServerSide": true,
//        	"sAjaxSource": "Home/AjaxHandler",
//        	"bProcessing": true,
//            "sPaginationType" : "full_numbers",
//        	"aoColumns": [
//                            {   "sName": "ID",
//                                "bSearchable": false,
//                                "bSortable": false,
//                                "fnRender": function (oObj) {
//                                    return '<a href=\"Company/Details/' + oObj.aData[0] + '\">View</a>';
//                                }
//                            },
//    			            { "sName": "COMPANY_NAME" },
//    			            { "sName": "ADDRESS" },
//    			            { "sName": "TOWN" }
//    		            ]
//        });
    companies.init();
});


//Revealing Module Pattern
//ISSUES : View link href not dynamic, the whole pattern is not working with IOC
var companies = function () {
    var dataTable = null;

    init = function () {
        getCompanies();
        //viewDetail();
        deleteCompany();
    },

                    getCompanies = function () {
                        //ajax call
                        $.ajax({
                            url: "/Home/GetCompanyies",
                            type: 'GET',
                            data: {
                        },
                        success: function (data) {
                            populateData(data.Companies);
                        },
                        error: function (e) {
                            alert("Error retrieving data for companies.");
                        }
                    });

                },

                    populateData = function (data) {
                        //poulate data table
                        if (dataTable != null) {
                            alert('data exists');
                            dataTable.fnClearTable();
                            dataTable.fnAddData(data);
                        } else {
                            dataTable = $("#tblSelect").dataTable({
                                "aaData": data,
                                "bDestroy": true,
                                "aaSorting": [],
                                "sPaginationType": "full_numbers",
                                "bJQueryUI": true,
                                "bProcessing": false,
                                "iDisplayLength": 500,
                                "bAutoWidth": false,
                                "bSort": false,
                                "sDom": 'R<"H"Cr>t<"F">',
                                "oLanguage": { "sEmptyTable": "No Data!!!!!!" },

                                "aoColumns": [
                            {
                                "sTitle": "ID",
                                "mDataProp": "ID",
                                "fnRender": function (obj) {
                                    return obj.aData.ID;
                                    // return "<a href=Company/Details/" + obj.aData.ID + ">View</a>"
                                }
                            },
                           {
                               "sTitle": "Comapany",
                               "mDataProp": "Name",
                               "fnRender": function (obj) {
                                   return obj.aData.Name;
                               }
                           },
                           {
                               "sTitle": "Address",
                               "mDataProp": "Address",
                               "fnRender": function (obj) {
                                   return obj.aData.Address;
                               }
                           },
                           {
                               "sTitle": "Town",
                               "mDataProp": "Town",
                               "fnRender": function (obj) {
                                   return obj.aData.Town;
                               }
                           },
                           {
                               mData: null,
                               "fnRender": function (obj) {
                                  return "<a href=Company/Details/" + obj.aData.ID + ">View</a>"
                               }
                              
                           },
                           {
                               mData: null,
                               sDefaultContent: "<a class='delete' href='javascript:void(0);'>Delete</a>"
                           }
                           ]
                            });
                        }
                    },

    //               viewDetail = function () {
    //                   $('#tblSelect a.detail').live('click', function (e) {
    //                       var nRow = $(this).parents('tr')[0];
    //                       var aData = dataTable.fnGetData(nRow);
    //                       alert(aData.ID);
    //                       $.ajax({
    //                           url: '/Company/Details',
    //                           type: 'GET',
    //                           data: { "id": aData.ID },
    //                           success: function (data) {
    //                               //window.location.href = ""Company/Details/112";
    //                           },
    //                           error: function (e) {
    //                               alert("Error in detail.");
    //                           }
    //                       });
    //                       return false;
    //                   });
    //               },

    deleteCompany = function () {
        $('#tblSelect a.delete').live('click', function (e) {
            var nRow = $(this).parents('tr')[0];
            var aData = dataTable.fnGetData(nRow);
            var msg = "Are you sure you want to delete company " + aData.Name + "?";
            var r = confirm(msg);
            if (r == true) {
                $.ajax({
                    url: '/Company/Delete',
                    type: 'POST',
                    data: { "id": aData.ID },
                    success: function (data) {
                        dataTable.fnDeleteRow(nRow);
                    },
                    error: function (e) {
                        alert("Error deleting company.");
                    }
                });
            }
            return false;
        });
    }
    return {
        init: init
    };
} ();