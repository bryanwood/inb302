<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Full/SiteCore.Full.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="homePageHeader" ContentPlaceHolderID="pageHeader" runat="server">
    <div class="coreHeaderUserContainer floatRight">
        logged in as <span class="coreExternalHighlight">example@company.com</span> | <a
            href="#">logout</a></div>
</asp:Content>
<asp:Content ID="homePageSidebar" ContentPlaceHolderID="pageSidebar" runat="server">
    <div class="sideBarHeading">
        Example User</div>
    <div class="sidebarTabGroup">
        <div class="sidebarTab coreExternalHighlight">
            home</div>
        <div class="sidebarTab" id="tabMyGroup">
            <a href="#">my groups</a></div>
    </div>
    <div class="sidebarTabGroup">
        <div class="sidebarTab" id="tabMyFiles">
            <a href="#">my files</a></div>
        <div class="sidebarTab" id="tabOtherFiles">
            <a href="#">files sent to me</a> <span class="sidebarTabBalloon">12</span></div>
    </div>
    <div class="sidebarTabGroup">
        <div class="sidebarTab" id="tabAdmin">
            <a href="#">administration</a></div>
        <div class="sidebarTab" id="tabSettings">
            <a href="#">settings</a></div>
    </div>
</asp:Content>
<asp:Content ID="homePageContent" ContentPlaceHolderID="pageContent" runat="server">
    <div class="contentBarMain floatLeft">
        <div class="contentPanel floatLeft">
            <div class="panelHeading">
                send a file</div>
            <div class="uploadSectionMajor floatFix">
                <input type="file" class="uploadUploadButton floatLeft" />
                <input type="button" class="uploadSendButton coreButtonAccept floatRight" value="Send" />
            </div>
        </div>
    </div>
    <div class="contentBarMini floatRight">
        <div class="contentPanel floatRight">
            <div class="panelHeading">
                recently recieved</div>
            <div class="floatFix" id="recentFiles">
                <div class="panelMiniSection floatFix">
                    <div class="panelMiniSectionMajorDetail panelDetailHighlight floatLeft">
                        Example File.doc</div>
                    <div class="panelMiniSectionEmail panelMiniSectionMinorDetail floatLeft">
                        important@company.com</div>
                    <div class="panelMiniSectionTime panelMiniSectionMinorDetail floatLeft">
                        1:31PM 6/09/2011</div>
                    <div class="panelMiniSectionLink panelMiniSectionMinorDetail floatLeft">
                        <a href="#" onclick="fakeAJAXPopup();">download</a></div>
                </div>
                <div class="panelMiniSection floatFix">
                    <div class="panelMiniSectionMajorDetail panelDetailHighlight floatLeft">
                        Important Document.doc</div>
                    <div class="panelMiniSectionEmail panelMiniSectionMinorDetail floatLeft">
                        another@company.com</div>
                    <div class="panelMiniSectionTime panelMiniSectionMinorDetail floatLeft">
                        9:03AM 6/09/2011</div>
                    <div class="panelMiniSectionLink panelMiniSectionMinorDetail floatLeft">
                        <a href="#">download</a></div>
                </div>
                <div class="panelMiniSection floatFix">
                    <div class="panelMiniSectionMajorDetail panelDetailHighlight floatLeft">
                        Pricing.doc</div>
                    <div class="panelMiniSectionEmail panelMiniSectionMinorDetail floatLeft">
                        sales@example.com</div>
                    <div class="panelMiniSectionTime panelMiniSectionMinorDetail floatLeft">
                        11:56AM 5/09/2011</div>
                    <div class="panelMiniSectionLink panelMiniSectionMinorDetail floatLeft">
                        <a href="#">download</a></div>
                </div>
            </div>
        </div>
        <div class="contentPanel floatRight">
            <div class="panelHeading">
                recently sent</div>
            <div class="floatFix" id="recentlySent">
                <div class="panelMiniSection floatFix">
                    <div class="panelMiniSectionMajorDetail panelDetailHighlight floatLeft">
                        Example File.doc</div>
                    <div class="panelMiniSectionEmail panelMiniSectionMinorDetail floatLeft">
                        multiple recipients</div>
                    <div class="panelMiniSectionTime panelMiniSectionMinorDetail floatLeft">
                        4:23PM 2/09/2011</div>
                    <div class="panelMiniSectionLink panelMiniSectionMinorDetail floatLeft">
                        <a href="#">details</a></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="homePageTitle" ContentPlaceHolderID="pageTitle" runat="server">
</asp:Content>
<asp:Content ID="homePageCSS" ContentPlaceHolderID="pageCSS" runat="server">
</asp:Content>
<asp:Content ID="homePageJS" ContentPlaceHolderID="pageJS" runat="server">
</asp:Content>
<asp:Content ID="homePageHeading" ContentPlaceHolderID="pageHeading" runat="server">
    <a class="coreExternalHighlight" href="Home">home</a>/
</asp:Content>
<asp:Content ID="homePageInnerJS" ContentPlaceHolderID="pageInnerJS" runat="server">
    <script type="text/javascript">
        function fakeAJAXPopup() {
            $("#lightBoxLightsOut").fadeIn(1000);
            $("#lightBoxContainer").fadeIn(1000);
            $("#lightBoxContainer").attr("src", "../../Main/DownloadLightBox");
        }
    </script>
</asp:Content>
