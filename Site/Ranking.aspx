<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MasterPage.Master" AutoEventWireup="true" CodeBehind="Ranking.aspx.cs" Inherits="TechNeuron_ATS.Site.Ranking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style>
.c1 {
  float: left;
  width: 50%;
}
.textcenter{
    text-align:center;
}

.rw:after {
  content: "";
  display: table;
  clear: both;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="rw">
        <div class="c1">
             <div class="rw">
                 <div class="c1"></div>
                  <div class="c1"></div>
            </div>
           <div class="rw textcenter">
               <h3>Add Ranking</h3>
           </div>
             <div class="rw textcenter">
                 
                     <asp:Label ID="RankingId" runat="server" Text="" Visible="false" ></asp:Label>
                  
            </div>
             <div class="rw">
                 <div class="c1"><br /></div>
                  <div class="c1"><br /></div>
            </div>
            <div class="rw">
                 <div class="c1 textcenter">
                     <asp:Label ID="Label1" runat="server" Text="Rank Title" Width="100px"></asp:Label>
                 </div>
                  <div class="c1">
                      <asp:TextBox ID="txtRankingTitle" runat="server"></asp:TextBox>
                 </div>
            </div>
             <div class="rw">
                 <div class="c1"><br /></div>
                  <div class="c1"><br /></div>
            </div>
             <div class="rw">
                 <div class="c1 textcenter"> <asp:Label ID="Label2" runat="server" Text="Ranking Desc" Width="100px"></asp:Label></div>
                  <div class="c1">   <asp:TextBox ID="txtRankingDesc" runat="server"></asp:TextBox></div>
            </div>
             <div class="rw">
                 <div class="c1"><br /></div>
                  <div class="c1"><br /></div>
            </div>
             <div class="rw">
                 <div class="c1 textcenter"> <asp:Label ID="Label3" runat="server" Text="Min Rank" Width="100px"></asp:Label></div>
                  <div class="c1"><asp:TextBox ID="txtMinRank" runat="server"></asp:TextBox></div>
            </div>
              <div class="rw">
                 <div class="c1"><br /></div>
                  <div class="c1"><br /></div>
            </div>
             <div class="rw">
                <div class="c1 textcenter"> <asp:Label ID="Label4" runat="server" Text="Max Rank" Width="100px"></asp:Label></div>
                  <div class="c1"><asp:TextBox ID="txtMaxRank" runat="server"></asp:TextBox></div>
            
            </div>
            <div class="rw">
                 <div class="c1"><br /></div>
                 <div class="c1"><br /></div>
                  <div class="c1"></div>
            </div>
             <div class="rw textcenter">
                 <asp:Button ID="btnSubmit" runat="server" Text="ADD RANK" OnClick="btnSubmit_Click" />
                 <asp:Button ID="btnclear" runat="server" Text="CLEAR" OnClick="btnclear_Click" />
            </div>
            
             <div class="rw">
                 <div class="c1"></div>
                  <div class="c1"></div>
            </div>
        </div>
         <div class="c1">
             <div class="rw textcenter">
               <h3>Job Position</h3>
           </div>
            <div class="rw">
                <asp:GridView ID="GDJobs" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" OnRowCommand="GDJobs_RowCommand">
       
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                    <asp:TemplateField>
                    <ItemTemplate>
                    <asp:Button Text="Edit" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
                    </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                    <SortedDescendingHeaderStyle BackColor="#3E3277" />
                </asp:GridView>
            </div>
              <div class="rw">
                 <div class="c1"></div>
                  <div class="c1"></div>
            </div>
        </div>
    </div>
</asp:Content>
