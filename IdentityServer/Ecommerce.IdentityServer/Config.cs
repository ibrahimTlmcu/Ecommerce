// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Data.Common;

namespace Ecommerce.IdentityServer
{
    public static class Config
    {

        //Burda cesıtlı yetkılerı tanımladıkç
        //Erısım duzeylerı belırlendı
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission"} },
           new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"} },
           new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"}},
           new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"} },
           new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission"} },
           new ApiResource("ResourceComment"){Scopes={"CommentFullPermission"} },
           new ApiResource("ResourcePayment"){Scopes={"PaymentFullPermission"} },
           new ApiResource("ResourceImage"){Scopes={"ImageFullPermission"} },
           new ApiResource("ResourceOcelot"){Scopes={"OcelotFullPermission"} },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope
            []
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog permission"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operatioens"),
            new ApiScope("DiscountFullPermission","Full authority for catalog operatioens"),
            new ApiScope("OrderFullPermission","Full authority for catalog operatioens"),
            new ApiScope("CargoFullPermission","Full authority for cargo operatioens"),
            new ApiScope("BasketFullPermission","Full authority for basket operatioens"),
            new ApiScope("CommentFullPermission","Full authority for comment operatioens"),
            new ApiScope("PaymentFullPermission","Full authority for payment operatioens"),
            new ApiScope("ImageFullPermission","Full authority for image operatioens"),
            new ApiScope("OcelotFullPermission","Full authority for ocelot operatioens"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        //Uc farkli kullanici tipi tanimladik
        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor yetkilendirme ilerleyince farkli yetkiler eklenecek.
            new Client
            {
                //Bu bilgiler ile Postman uzerinden test edecegiz 
                //clinet_id client_secret grand_type
                //Bu kisimlar.
                ClientId = "EcommerceVisitorId",
                ClientName = "EcommerceVisitorUser",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets ={new Secret ("ecommercesecret".Sha256())},
                AllowedScopes = { "CatalogReadPermission", "DiscountFullPermission", 
                    "CatalogFullPermission", "OcelotFullPermission","CommentFullPermission","ImageFullPermission" }
                
            },
            //Manager
            new Client
            {
                ClientId ="EcommerceManagerId",
                ClientName ="EcommerceManagerUser",
                ClientSecrets ={new Secret ("ecommercesecret".Sha256())},
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                AllowedScopes ={ "CatalogFullPermission", "CatalogReadPermission","BasketFullPermission",
                    "OcelotFullPermission","CommentFullPermission","PaymentFullPermission","ImageFullPermission",
                  IdentityServerConstants.LocalApi.ScopeName,
                  IdentityServerConstants.StandardScopes.Email,
                  IdentityServerConstants.StandardScopes.Profile,
                  IdentityServerConstants.StandardScopes.OpenId,
                },
                AccessTokenLifetime = 600
            },
            //Admin
            new Client
            {
                ClientId ="EcommerceAdminId",
                ClientName ="EcommerceAdminUser",
                ClientSecrets ={new Secret ("ecommercesecret".Sha256())},
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,        
                AllowedScopes={ "CatalogFullPermission", "OrderFullPermission","CatalogReadPermission", 
                    "DiscountFullPermission","CargoFullPermission","OcelotFullPermission",
                    "BasketFullPermission","OcelotFullPermission","CommentFullPermission",
                    "PaymentFullPermission","ImageFullPermission","CargoFullPermission","CommentFullPermission",
                    "PaymentFullPermission","ImageFullPermission",
                  IdentityServerConstants.LocalApi.ScopeName,
                  IdentityServerConstants.StandardScopes.Email,
                  IdentityServerConstants.StandardScopes.Profile,
                  IdentityServerConstants.StandardScopes.OpenId,
                },
                AccessTokenLifetime = 600
            }
            //
        };

        
    }
}