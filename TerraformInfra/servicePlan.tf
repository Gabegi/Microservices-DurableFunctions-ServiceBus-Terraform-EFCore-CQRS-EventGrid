resource "azurerm_service_plan" "asp-functionapp" {
  name                = "dionysos-asp-functionapp-${var.environment}"
  resource_group_name = azurerm_resource_group.infrastructure-rg.name
  location            = azurerm_resource_group.infrastructure-rg.location
  os_type             = "Windows"
  sku_name            = "Y1"
}
