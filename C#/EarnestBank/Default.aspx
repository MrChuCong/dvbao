<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
<form id="FORM" runat="server">
    <div style="text-align:center">
        <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" class="page_title">WELCOME TO EARNEST BANK</td>
        </tr>
        <tr>
            <td class="field">
                <p style="text-align:justify; padding-bottom:40px">Welcome to a world of banking products and services developed to delight you in every way! Whether you are a student, an individual with big dreams, or corporate, you’ll find Earnest Bank is the right financial partner. Feel free to browse through our entire range of products and services to see which one suits you best.</p>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="left" class="ads_title">Personal Banking</td>
                    <td style="width:10px"></td>
                    <td align="left" class="ads_title">Business and Commercial</td>
                </tr>
                <tr>
                    <td align="left"><a href="Products.aspx"><img src="images/homepage-banner-personal.jpg" style="border:solid thin #421101 1px" alt="" /></a></td>
                    <td style="width:50px"></td>
                    <td align="left"><a href="Products.aspx"><img src="images/homepage-banner-business.jpg" style="border:solid thin #421101 1px" alt="" /></a></td>
                </tr>
                <tr>
                    <td style="height:30px"></td>
                </tr>
                <tr>
                    <td align="left" class="ads_title">Global Banking and Markets</td>
                    <td style="width:50px"></td>
                    <td align="left" class="ads_title">Private Banking</td>
                </tr>
                <tr>
                    <td align="left"><a href="Products.aspx"><img src="images/homepage-banner-specialist.jpg" style="border:solid thin #421101 1px" alt="" /></a></td>
                    <td style="width:10px"></td>
                    <td align="left"><a href="Products.aspx"><img src="images/homepage-banner-private.jpg" style="border:solid thin #421101 1px" alt="" /></a></td>
                </tr>
                </table>
            </td>
        </tr>        
        </table>
    </div>
</form>
</asp:Content>