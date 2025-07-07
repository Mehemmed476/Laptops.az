namespace LaptopsAz.Core.Enums;

public enum ComputerSpecification
{
    Processor,          // CPU model, cores, threads, frequency
    RAM,                // Size, type, and speed of memory
    GraphicsCard,       // GPU model and type (integrated/dedicated)
    Storage,            // SSD/HDD type and capacity
    Motherboard,        // Chipset and connectivity options
    Display,            // Screen size, resolution, refresh rate
    Battery,            // Capacity and estimated life (for laptops)
    CoolingSystem,      // Fan setup or thermal solution
    OperatingSystem,    // Windows, macOS, Linux etc.
    PortsAndConnectivity, // USB, HDMI, Wi-Fi, Bluetooth etc.
    Keyboard,           // Layout, backlight, switch type
    Weight,             // Device weight (important for laptops)
    BuildMaterial       // Plastic, Aluminum, Magnesium etc.
}