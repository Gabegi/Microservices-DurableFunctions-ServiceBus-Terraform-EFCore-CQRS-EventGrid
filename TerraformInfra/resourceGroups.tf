resource "azurerm_resource_group" "infrastructure-rg" {
  name     = "dionysos-rg-${var.environment}"
  location = "West Europe"
}