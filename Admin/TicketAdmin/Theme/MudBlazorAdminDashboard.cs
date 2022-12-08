using MudBlazor;

namespace TicketFanAdmin.Theme;

public class MudBlazorAdminDashboard : MudTheme
{
    public MudBlazorAdminDashboard()
    {
        Palette.Primary = "#FC4A88";
        Palette.Secondary = "#942DBD";
        PaletteDark.Primary = "#FC4A88";
        PaletteDark.Secondary = "#942DBD";
        Palette.Background = "#A0A0A0";
        Palette.Divider = "#0000001e";
        LayoutProperties.DefaultBorderRadius = "6px";
    }
}