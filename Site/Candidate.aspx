﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MasterPage.Master" AutoEventWireup="true" CodeBehind="Candidate.aspx.cs" Inherits="TechNeuron_ATS.Site.Candidate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
      <div class="row">
         <div class="col-md-6">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                         <%--<center>
                           <img width="100px" src="imgs/generaluser.png"/>
                        </center>--%>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Candidate Profile</h4>
                           <span>Account Status - </span>
                           <asp:Label class="badge badge-pill badge-info" ID="lblStatus" runat="server" Text="Your status"></asp:Label>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtName" runat="server" placeholder="Full Name"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Date of Birth</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtDOB" runat="server" placeholder="Password" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Mobile No</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtMobileNo" runat="server" placeholder="Mobile No" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Email ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtEmailId" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Select Job Position</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="ddlJob" runat="server">
                           </asp:DropDownList>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>City</label>
                        <div class="form-group">
                            <asp:HiddenField ID="HFMinValue" runat="server" />
                            <asp:HiddenField ID="HFMaxValue" runat="server" />
                        </div>
                     </div>
                    
                  </div>
                  <div class="row">
                     <div class="col">
                        <label>Qualification</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtQualification" runat="server" placeholder="Qualification" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                 <div class="row">
                     <div class="col">
                        <label>CV File Location</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtfilelocation" runat="server" placeholder="CV File Locations"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  

                    <div class="row">
                     <div class="col-md-4">
                        <label>Add Skills</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="ddlSkills" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSkills_SelectedIndexChanged">
                           </asp:DropDownList>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Rating</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="txtRating" runat="server" placeholder="Rate"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label> <asp:TextBox class="form-control" ID="txtRatingScore" runat="server" placeholder="RatingScore" Enabled="false"></asp:TextBox></label>
                        <div class="form-group">
                            <asp:Button class="btn btn-primary btn-block btn-sm" ID="btnAdd" runat="server" Text="AddRow" OnClick="btnAdd_Click" />
                        </div>
                     </div>
                  </div>
                   
                       <div class="row">
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GVSkillSet" runat="server"></asp:GridView>
                     </div>
                  </div>
                   

                  <div class="row">
                     <div class="col-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Save" />
                           </div>
                        </center>
                     </div>
                  </div>
               </div>
            </div>
           
         </div>
         <div class="col-md-6">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                       
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Your Issued Books</h4>
                           <asp:Label class="badge badge-pill badge-info" ID="Label2" runat="server" Text="your books info"></asp:Label>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="grdCandidate" runat="server"></asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>

</asp:Content>
