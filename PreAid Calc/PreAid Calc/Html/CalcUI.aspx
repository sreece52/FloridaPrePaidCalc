<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalcUI.aspx.cs" Inherits="PreAid_Calc.CalcUI" EnableEventValidation="false" %>

<!DOCTYPE html>
<html>
<head>
    <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.5/angular.min.js"></script>
    <link rel="stylesheet" type="text/css" href="/Style/pageStyle.css">
</head>
<body>

    <!--BootStrap viewport container-->

    <div id="contentPane">
        <div class="container">
            <div class="well">
                <!-- The main content pane to hold the other componenets -->
                <!-- Holds the title pane -->

                <h2>FLORIDA PRE-PAID BENEFITS CALCULATOR  </h2>


                <hr>

                <!--The first question the user is asked panel-->
                <form action="" runat="server">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="panel panel-default">
                                <div id="q1" class="panel-heading">Is your Florida Pre-Paid contract year prior to July 1, 2007</div>
                                <div class="panel-body">
                                    <asp:RadioButton type="radio" name="yes" ID="q1rbtyes" value="yes" runat="server" OnCheckedChanged="q1rbtyes_CheckedChanged" AutoPostBack="true" />
                                    Yes
                                    <asp:RadioButton type="radio" name="no" ID="q1rbtno" value="no" runat="server" OnCheckedChanged="q1rbtno_CheckedChanged" AutoPostBack="true" />
                                    No
                                </div>
                            </div>
                        </div>
                    </div>
                    <br>

                    <!--The second question panel-->
                    <div class="row">
                        <div class="col-md-12">
                            <div class="panel panel-default">
                                <div id="q2" class="panel-heading">Did you purchase the optional Local Fees Plan?</div>
                                <div class="panel-body">
                                    <asp:RadioButton type="radio" name="yes" ID="q2rbtyes" value="yes" runat="server" OnCheckedChanged="q2rbtyes_CheckedChanged" AutoPostBack="true" />
                                    Yes
                                <asp:RadioButton type="radio" name="no" ID="q2rbtno" value="no" runat="server" OnCheckedChanged="q2rbtno_CheckedChanged" AutoPostBack="true" />
                                    No
                                </div>
                            </div>
                        </div>
                    </div>

                    <br>

                    <!--Third question panel -->
                    <div class="row">
                        <div class="col-md-12">
                            <div class="panel panel-default">
                                <div id="q3" class="panel-heading">Did you purchase the optional Differential Fee Plan?</div>
                                <div class="panel-body">
                                    <asp:RadioButton type="radio" name="yes" ID="q3rbtyes" value="yes" runat="server" OnCheckedChanged="q3rbtyes_CheckedChanged" AutoPostBack="true" />
                                    Yes
                                <asp:RadioButton type="radio" name="no" ID="q3rbtno" value="no" runat="server" OnCheckedChanged="q3rbtno_CheckedChanged" AutoPostBack="true" />
                                    No
                                </div>
                            </div>
                        </div>
                    </div>

                    <br>

                    <!--Fourth question panel-->
                    <div class="row">
                        <div class="col-md-12">
                            <div class="panel panel-default">
                                <div id="q4" class="panel-heading">How many credit hours do you anticipate to take per term?</div>
                                <div class="panel-body">
                                    <form action="">
                                        <asp:TextBox type="text" ID="credHours" value="0" runat="server" OnTextChanged="creditHours_TextChanged" AutoPostBack="true" />
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>

                    <hr>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="panel panel-default">
                                <div id="r1" class="panel-heading"> Results </div>
                                <div class="panel-body">
                                    Total Estimated Tuition & Fees:
                                    <asp:TextBox data-toggle="tooltip" title="Credit hours * Tuition per credit hour" type="text" ID="estTuititon" value="" Enabled="false" runat="server" />
                                    <br><hr/>
                                    Total Estimated Florida Prepaid Benefit:
                                    <asp:TextBox data-toggle="tooltip" title="(Tuition Plan + Local Fees Plan + Differential Fee Plan) * Credit Hours" type="text" ID="estBenefit" value="" Enabled="false" runat="server" />
                                    <br><hr/>
                                    Your Estimated Out-of-Pocket Tuition & Fee Cost (per term):
                                    <asp:TextBox data-toggle="tooltip" title="Total Estimated Tuition & Fees - Total Estimated Florida Prepaid Benefit" type="text" ID="estOutOfPocket" value="" Enabled="false" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>

