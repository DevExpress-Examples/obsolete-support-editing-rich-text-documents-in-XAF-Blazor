# How to support editing rich text documents in XAF Blazor

## Scenario
XAF's WinForms and WebForms apps support the [Office Module](https://docs.devexpress.com/eXpressAppFramework/400003/concepts/extra-modules/office-module/office-module-overview) for editing rich text documents. This Module integrates our WinForms RichEditControl and ASP.NET ASPxRichEdit controls into platform-specific Property Editors. Until the Office Module supports Blazor UI, it is possible to implement this functionality manually.

## Solution
In this example, we create a custom Property Editor for XAF Blazor to edit rich text documents. We use our [ASP.NET Core Rich Text Editor](https://docs.devexpress.com/AspNetCore/400373/rich-edit) in the custom Property Editor. The following article describes how to create a custom Property Editor in XAF Blazor: [How to: Implement a Property Editor Based on a Custom Component (Blazor)](https://docs.devexpress.com/eXpressAppFramework/402189/task-based-help/property-editors/how-to-implement-a-property-editor-based-on-custom-components-blazor?p=netstandard).
To easily re-use our custom Property Editor in an XAF Blazor application, we implement it in a Module. You can find its resulting code at [RichText.Module.Blazor](RichText.Module.Blazor).
![result](media/Screenshot.png)

## Implementation Steps
**Step 1.** In the Solution Explorer, include **RichText.Module.Blazor.csproj** in your XAF Blazor solution and then reference this RichText.Module.Blazor project in the *YourSolutionName.Blazor.Server* project. In the *YourSolutionName.Blazor.Server/BlazorApplication.cs* file, create a RichText.Module.Blazor.RichTextBlazorModule instance and add it to the Modules collection. For more information, see [Add a Module in Code](https://docs.devexpress.com/eXpressAppFramework/118047/concepts/application-solution-components/ways-to-register-a-module#code).

**Step 2.** In the *YourSolutionName.Blazor.Server/Startup.cs* file, add the `services.AddRichTextBlazorModule();` line to the `Startup.ConfigureServices` method.

**Step 3.** A rich text document is stored as a base64 string and may be long. By default, Blazor Server allows transferring only 32KB through a SignalR hub. This may not be sufficient. Set the [HubOptions\.MaximumReceiveMessageSize](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.signalr.huboptions.maximumreceivemessagesize?view=aspnetcore-5.0#Microsoft_AspNetCore_SignalR_HubOptions_MaximumReceiveMessageSize) property to `null` in the `Startup.ConfigureServices` method.

```cs
public void ConfigureServices(IServiceCollection services) {
    services.AddRazorPages();
    services.AddServerSideBlazor()
        .AddHubOptions(opt => {  //!!!
            opt.MaximumReceiveMessageSize = null;  //!!!
        });  //!!!
    services.AddHttpContextAccessor();
    services.AddSingleton<XpoDataStoreProviderAccessor>();
    services.AddScoped<CircuitHandler, CircuitHandlerProxy>();
    services.AddXaf<Solution1BlazorApplication>(Configuration);
    services.AddRichTextBlazorModule(); //!!!
}
```

**Step 4.** Make sure that you declared a byte array property for your rich text content as described at [Assign the Rich Text Property Editor to a Business Class' Property](https://docs.devexpress.com/eXpressAppFramework/400004/concepts/extra-modules/office-module/use-rich-text-documents-in-business-objects#in-code) . For more information, see the [Document](Solution1.Module/BusinessObjects/Document.cs#L27) class.
