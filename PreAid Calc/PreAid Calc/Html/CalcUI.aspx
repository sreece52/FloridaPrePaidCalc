﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalcUI.aspx.cs" Inherits="PreAid_Calc.CalcUI" %>

<!DOCTYPE html>
<html>
<head>
    <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
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
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-default">
                            <div id="q1" class="panel-heading">Is you Florida Pre-Paid contract year prior to July 1, 2007</div>
                            <div class="panel-body">
                                <form action="">
                                    <input type="radio" name="yes" id="q1rbtyes" value="yes" runat="server" /> Yes
                                    <input type="radio" name="no" id="q1rbtno" value="no" runat="server"> No
                                </form>
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
                                <form action="">
                                    <input type="radio" name="yes" id="q2rbtyes" value="yes" /> Yes
                                    <input type="radio" name="no" id="q2rbtno" value="no"> No
                                </form>
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
                                <form action="">
                                    <input type="radio" name="yes" id="q3rbtyes" value="yes" /> Yes
                                    <input type="radio" name="no" id="q3rbtno" value="no"> No
                                </form>
                            </div>
                        </div>
                    </div>
                </div>

                <br>

                <!--Fourth question panel-->
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-default">
                            <div id="q4" class="panel-heading"> How many credit hours do you anticipate to take per term?</div>
                            <div class="panel-body">
                                <form action="">
                                    <input type="text" id="creditHours" value="12" />
                                </form>
                            </div>
                        </div>
                    </div>
                </div>

                <hr>

                <!--Results table-->
                <div id="tableHolder" class="well">
                    <table class="table">
                        <thead>
                            <tr>
                                <th>Category</th>
                                <th>Estimate</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td><em>Total Estimated Tuition & Fees: </em></td>
                                <td><input data-toggle="tooltip" title="Credit hours * Tuition per credit hour" type="text" id="estTuititon" value="" /></td>
                            </tr>
                            <tr>
                                <td><em>Total Estimated Florida Prepaid Benefit: </em></td>
                                <td><input data-toggle="tooltip" title="(Tuition Plan + Local Fees Plan + Differential Fee Plan) * Credit Hours" type="text" id="estBenefit" value="" /></td>
                            </tr>
                            <tr>
                                <td><em>Your Estimated Out-of-Pocket Tuition & Fee Cost (per term): </em></td>
                                <td><input data-toggle="tooltip" title="Total Estimated Tuition & Fees - Total Estimated Florida Prepaid Benefit" type="text" id="estOutOfPocket" value="" /></td>
                            </tr>
                            <tr>
                                <td><em>Estimated % of cost covered by Florida Prepaid: </em></td>
                                <td><input data-toggle="tooltip" title="Total Estimated Florida Prepaid Benefit / Total Estimated Tuition & Fees" type="text" id="percentCovered" value="" /></td>
                            </tr>
                        </tbody>
                    </table>
                </div>

            </div>
        </div>
    </div>
</body>
</html>
