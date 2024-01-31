resource "azurerm_public_ip" "pip" {
  name                = "dionysos-publicIP-${var.environment}"
  resource_group_name = azurerm_resource_group.infrastructure-rg.name
  location            = azurerm_resource_group.infrastructure-rg.location
  allocation_method   = "Static"
  sku                 = "Standard"
}

# resource "azurerm_application_gateway" "app-gateway" {
#   name                = "dionysos-AppGateway-${var.environment}"
#   resource_group_name = azurerm_resource_group.infrastructure-rg.name
#   location            = azurerm_resource_group.infrastructure-rg.location

#   sku {
#     name     = "Standard_v2"
#     tier     = "Standard_v2"
#     capacity = 2
#   }

#   gateway_ip_configuration {
#     name      = "dionysos--gateway-ipConfiguration-${var.environment}"
#     subnet_id = azurerm_subnet.subnet-3.id
#   }

#   frontend_port {
#     name = "dionysos-frontendPort-${var.environment}"
#     port = 80
#   }

#   frontend_ip_configuration {
#     name                 = "dionysos-frontendIP-Config-${var.environment}"
#     public_ip_address_id = azurerm_public_ip.pip.id
#   }

#   backend_address_pool {
#     name = "dionysos-backendAddressPool-${var.environment}"
#   }

#   backend_http_settings {
#     name                  = "dionysos-httpSettings-${var.environment}"
#     cookie_based_affinity = "Disabled"
#     port                  = 80
#     protocol              = "Http"
#     request_timeout       = 60
#     path                  = "/api"  # Adjust this path to match your Function App routes
#   }

#   http_listener {
#     name                           = "dionysos-listener-${var.environment}"
#     frontend_ip_configuration_name = "dionysos-frontendIP-Config-${var.environment}"
#     frontend_port_name             = "dionysos-frontendPort-${var.environment}"
#     protocol                       = "Http"
#   }

#   request_routing_rule {
#     name                       = "dionysos-routing-rule-${var.environment}"
#     rule_type                  = "Basic"
#     http_listener_name         = "dionysos-listener-${var.environment}"
#     backend_address_pool_name  = "dionysos-backendAddressPool-${var.environment}"
#     backend_http_settings_name = "dionysos-httpSettings-${var.environment}"
#     priority                   = 1
#   }
# }

# resource "azurerm_network_interface" "nic-routing" {
#   name                = "dionysos-nic-routing-${var.environment}"
#   location            = azurerm_resource_group.infrastructure-rg.location
#   resource_group_name = azurerm_resource_group.infrastructure-rg.name

#   ip_configuration {
#     name                          = "dionysos-nic-routing-ipconfig-${var.environment}"
#     subnet_id                     = azurerm_subnet.subnet-4.id
#     private_ip_address_allocation = "Dynamic"
#   }
# }

# resource "azurerm_network_interface_application_gateway_backend_address_pool_association" "nic-assoc" {
#   network_interface_id    = azurerm_network_interface.nic-routing.id
#   ip_configuration_name   = "dionysos-nic-routing-ipconfig-${var.environment}"
#   backend_address_pool_id = one(azurerm_application_gateway.app-gateway.backend_address_pool).id
# }