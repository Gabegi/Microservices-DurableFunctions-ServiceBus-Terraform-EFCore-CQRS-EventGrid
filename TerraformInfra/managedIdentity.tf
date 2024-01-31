resource "azurerm_user_assigned_identity" "managed_identity" {
  name                = "dionysos-managed-identity-${var.environment}"
  location            = "West Europe"
  resource_group_name = azurerm_resource_group.infrastructure-rg.name
}

## not allowed in my case (AD policy) > set in the portal

# resource "azurerm_role_assignment" "assign_identity_storage_blob_data_contributor" {
#   scope                = azurerm_storage_account.strg-account-data.id
#   role_definition_name = "Storage Blob Data Contributor"
#   principal_id         = azurerm_user_assigned_identity.managed_identity.principal_id
# }

output "client_id" {
  value = azurerm_user_assigned_identity.managed_identity.client_id
}

# data "azurerm_user_assigned_identity" "service-principal" {
#   name                =  var.serviceprincipal_username
#   resource_group_name = "name_of_resource_group"
# }
