<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Mini/SiteCore.Mini.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="downloadPageTitle" ContentPlaceHolderID="pageTitle" runat="server">
    uFile | Download</asp:Content>
<asp:Content ID="downloadPageHeading" ContentPlaceHolderID="pageHeading" runat="server">
    download
</asp:Content>
<asp:Content ID="downloadPageContent" ContentPlaceHolderID="pageContent" runat="server">
    <div class="miniBoxSection miniBoxImportantHighlight" id="majorInfo">
        <div class="miniSectionDetail floatFix" id="fileName">
            <div class="miniLabel floatLeft">
                File Name:</div>
            <div class="miniDescription floatLeft">
                Example File.doc</div>
        </div>
        <div class="miniSectionDetail floatFix" id="fileSender">
            <div class="miniLabel floatLeft">
                Sender:</div>
            <div class="miniDescription floatLeft">
                someone@company.com</div>
        </div>
    </div>
    <input id="downloadInfoExpandButton" type="button" class="coreButtonAccept floatRight"
        value="Show Additional Information" onclick="showAdditionalInformation();" />
    <div class="miniBoxSection miniBoxInformationHighlight floatClear" id="minorInfo"
        style="display: none; opacity:0.0;">
        <div class="miniSectionDetail floatFix" id="fileUploaded">
            <div class="miniLabel floatLeft">
                Uploaded:</div>
            <div class="miniDescription floatLeft">
                5/09/2011</div>
        </div>
        <div class="miniSectionDetail floatFix" id="fileSize">
            <div class="miniLabel floatLeft">
                Size:</div>
            <div class="miniDescription floatLeft">
                6 MB</div>
        </div>
    </div>
    <div class="coreMiniBoxUserAction">
        <input type="button" class="miniButton floatLeft coreButtonAccept" value="Download" />
        <input type="button" class="miniButton floatLeft coreButtonCancel" value="Cancel" />
    </div>
</asp:Content>
<asp:Content ID="downloadPageInnerJS" ContentPlaceHolderID="pageInnerJS" runat="server">
    <script type="text/javascript">
        function showAdditionalInformation() {
            if ($("#minorInfo").css("display") == "none") {
                $("#downloadInfoExpandButton").val("Hide Additional Information");
                $("#minorInfo").slideDown(500);
                $("#minorInfo").animate({ opacity: 1.0 }, 500);
            } else {
                $("#downloadInfoExpandButton").val("Show Additional Information");
                $("#minorInfo").animate({ opacity: 0.0 }, 500);
                $("#minorInfo").slideUp(500);
            }
        }
    </script>
</asp:Content>
