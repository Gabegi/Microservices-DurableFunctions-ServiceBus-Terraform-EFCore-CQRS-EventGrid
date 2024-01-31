resource "azurerm_virtual_network" "vnet" {
  name                = "dionysos-vnet-${var.environment}"
  address_space       = ["10.0.0.0/16"]
  location            = azurerm_resource_group.infrastructure-rg.location
  resource_group_name = azurerm_resource_group.infrastructure-rg.name
}

resource "azurerm_subnet" "subnet-1" {
  name                 = "dionysos-subnet-compute-${var.environment}"
  resource_group_name  = azurerm_resource_group.infrastructure-rg.name
  virtual_network_name = azurerm_virtual_network.vnet.name
  address_prefixes     = ["10.0.1.0/24"]
}

  resource "azurerm_subnet" "subnet-2" {
  name                 = "dionysos-subnet-data-${var.environment}"
  resource_group_name  = azurerm_resource_group.infrastructure-rg.name
  virtual_network_name = azurerm_virtual_network.vnet.name
  address_prefixes     = ["10.0.2.0/24"]
  }

   resource "azurerm_subnet" "subnet-3" {
  name                 = "dionysos-subnet-appGateway-${var.environment}"
  resource_group_name  = azurerm_resource_group.infrastructure-rg.name
  virtual_network_name = azurerm_virtual_network.vnet.name
  address_prefixes     = ["10.0.3.0/24"]
  }

   resource "azurerm_subnet" "subnet-4" {
  name                 = "dionysos-subnet-routing-${var.environment}"
  resource_group_name  = azurerm_resource_group.infrastructure-rg.name
  virtual_network_name = azurerm_virtual_network.vnet.name
  address_prefixes     = ["10.0.4.0/24"]
  }

  resource "azurerm_subnet" "subnet-5" {
  name                 = "dionysos-subnet-functionapps-${var.environment}"
  resource_group_name  = azurerm_resource_group.infrastructure-rg.name
  virtual_network_name = azurerm_virtual_network.vnet.name
  address_prefixes     = ["10.0.5.0/24"]

  service_endpoints = ["Microsoft.Storage"]
  }


