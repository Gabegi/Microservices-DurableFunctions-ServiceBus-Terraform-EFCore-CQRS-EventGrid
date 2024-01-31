resource "azurerm_storage_account" "strg-account-compute" {
  name                     = "dionysoscompute${var.environment}"
  resource_group_name      = azurerm_resource_group.infrastructure-rg.name
  location                 = azurerm_resource_group.infrastructure-rg.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

# resource "azurerm_storage_account_network_rules" "sa-network-rule-compute" {
#   storage_account_id          = azurerm_storage_account.strg-account-compute.id
#   default_action              = "Deny"
#   virtual_network_subnet_ids  = [azurerm_subnet.subnet-5.id]
#   bypass                      = ["Metrics"]
# }

# resource "azurerm_private_endpoint" "pe-storage-account" {
#   name                = "${azurerm_storage_account.strg-account-compute.name}-endpoint"
#   location            = azurerm_resource_group.infrastructure-rg.location
#   resource_group_name = azurerm_resource_group.infrastructure-rg.name
#   subnet_id           = azurerm_subnet.subnet-5.id
  

#   private_service_connection {
#     name                           = "${azurerm_storage_account.strg-account-compute.name}-privateconnection"
#     private_connection_resource_id = azurerm_storage_account.strg-account-compute.id
#     subresource_names = ["blob"]
#     is_manual_connection = false
#   }
# }

// https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/storage_account

resource "azurerm_storage_account" "strg-account-data" {
  name                     = "dionysosdata${var.environment}"
  resource_group_name      = azurerm_resource_group.infrastructure-rg.name
  location                 = azurerm_resource_group.infrastructure-rg.location
  account_tier             = "Standard"
  account_replication_type = "LRS"

  # identity {
  #   type = "UserAssigned"
  #   identity_ids = [
  #     azurerm_user_assigned_identity.managed_identity.id
  #   ]
  # }

}

resource "azurerm_storage_table" "InventoryTable" {
  name                 = "redwineinventorytable"
  storage_account_name = azurerm_storage_account.strg-account-data.name
}