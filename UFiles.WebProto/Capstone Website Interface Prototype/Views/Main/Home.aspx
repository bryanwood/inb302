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
    <div class="contentBarFull">
        <div class="contentPanel floatFix floatLeft">
            <div class="uploadHeading floatLeft">
                send a file</div>
            <div class="uploadSectionMajor floatLeft floatFix">
                <input type="button" class="uploadSendButton coreButtonAccept floatRight" value="Send" />
                <input type="file" class="uploadUploadButton floatRight" />
            </div>
        </div>
    </div>
    <div class="homeView floatFix">
        <div class="contentBarMain floatLeft">
            <div class="contentPanel floatLeft">
                <div class="detailsSection">
                    <div class="detailsMajor">
                        <div class="detailsInnerSection" id="fileName">
                            <span class="detailsHighlight">Important Document.doc</span>
                        </div>
                        <div class="detailsInnerSection" id="fileSender">
                            sent by <span class="detailsHighlight">another@company.com</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="contentBarMini floatRight">
            <div class="contentPanel floatRight">
                <div class="panelHeading floatFix">
                    <a href="#" onclick="flipState('recentlySent', 'sentTab', 'recentlyRecieved', 'recievedTab');"><div class="panelTab panelTabSelected floatLeft" id="recievedTab">recently recieved</div></a>
                    <a href="#" onclick="flipState('recentlyRecieved', 'recievedTab', 'recentlySent', 'sentTab');"><div class="panelTab floatRight" id="sentTab">recently sent</div></a></div>
                <div class="floatFix" id="recentlySent">
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
                    <div class="panelMiniSection panelSectionSelectedHighlight floatFix">
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
            <div class="contentPanel floatRight" id="recentlyRecieved" style="display: none; opacity: 0.0;">
                <div class="floatFix" id="recentlySent">
                    <div class="panelMiniSection floatFix">
                        <div class="panelMiniSectionMajorDetail panelDetailHighlight floatLeft">
                            Example File.doc</div>
                        <div class="panelMiniSectionEmail panelMiniSectionMinorDetail floatLeft">
                            multiple recipients</div>
                        <div class="panelMiniSectionTime panelMiniSectionMinorDetail floatLeft">
                            4:23PM 2/09/2011</div>
                        <div class="panelMiniSectionLink panelMiniSectionMinorDetail floatLeft">
                            <a href="#">edit</a></div>
                    </div>
                                        <div class="panelMiniSection floatFix">
                        <div class="panelMiniSectionMajorDetail panelDetailHighlight floatLeft">
                            Example File.doc</div>
                        <div class="panelMiniSectionEmail panelMiniSectionMinorDetail floatLeft">
                            multiple recipients</div>
                        <div class="panelMiniSectionTime panelMiniSectionMinorDetail floatLeft">
                            4:23PM 2/09/2011</div>
                        <div class="panelMiniSectionLink panelMiniSectionMinorDetail floatLeft">
                            <a href="#">edit</a></div>
                    </div>
                                        <div class="panelMiniSection floatFix">
                        <div class="panelMiniSectionMajorDetail panelDetailHighlight floatLeft">
                            Example File.doc</div>
                        <div class="panelMiniSectionEmail panelMiniSectionMinorDetail floatLeft">
                            multiple recipients</div>
                        <div class="panelMiniSectionTime panelMiniSectionMinorDetail floatLeft">
                            4:23PM 2/09/2011</div>
                        <div class="panelMiniSectionLink panelMiniSectionMinorDetail floatLeft">
                            <a href="#">edit</a></div>
                    </div>
                                        <div class="panelMiniSection floatFix">
                        <div class="panelMiniSectionMajorDetail panelDetailHighlight floatLeft">
                            Example File.doc</div>
                        <div class="panelMiniSectionEmail panelMiniSectionMinorDetail floatLeft">
                            multiple recipients</div>
                        <div class="panelMiniSectionTime panelMiniSectionMinorDetail floatLeft">
                            4:23PM 2/09/2011</div>
                        <div class="panelMiniSectionLink panelMiniSectionMinorDetail floatLeft">
                            <a href="#">edit</a></div>
                    </div>
                                        <div class="panelMiniSection floatFix">
                        <div class="panelMiniSectionMajorDetail panelDetailHighlight floatLeft">
                            Example File.doc</div>
                        <div class="panelMiniSectionEmail panelMiniSectionMinorDetail floatLeft">
                            multiple recipients</div>
                        <div class="panelMiniSectionTime panelMiniSectionMinorDetail floatLeft">
                            4:23PM 2/09/2011</div>
                        <div class="panelMiniSectionLink panelMiniSectionMinorDetail floatLeft">
                            <a href="#">edit</a></div>
                    </div>
                                        <div class="panelMiniSection floatFix">
                        <div class="panelMiniSectionMajorDetail panelDetailHighlight floatLeft">
                            Example File.doc</div>
                        <div class="panelMiniSectionEmail panelMiniSectionMinorDetail floatLeft">
                            multiple recipients</div>
                        <div class="panelMiniSectionTime panelMiniSectionMinorDetail floatLeft">
                            4:23PM 2/09/2011</div>
                        <div class="panelMiniSectionLink panelMiniSectionMinorDetail floatLeft">
                            <a href="#">edit</a></div>
                    </div>
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
        };
        function flipState(show, showTab, hide, hideTab) {
            $("#" + showTab).addClass("panelTabSelected");
            $("#" + hideTab).removeClass("panelTabSelected");
            $("#" + show).animate({ opacity: 1.0 }, 500);
            $("#" + show).slideDown(500);
            $("#" + hide).animate({ opacity: 0.0 }, 500);
            $("#" + hide).slideUp(500);
        };
    </script>
</asp:Content>
