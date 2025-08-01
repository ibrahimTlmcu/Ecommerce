# MultiShop

[![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](https://github.com/USERNAME/MultiShop/actions)  
[![License](https://img.shields.io/badge/license-MIT-blue)](#license)  
[![.NET](https://img.shields.io/badge/.NET-8.0-blue)](https://dotnet.microsoft.com/)  
[![Docker](https://img.shields.io/badge/docker-enabled-blue)](https://www.docker.com/)

## Açıklama

**MultiShop**, gerçek dünya e-ticaret senaryosu üzerinden geliştirilen, mikroservis mimarisiyle inşa edilmiş kapsamlı bir öğrenme projesidir.  
Bu proje ile ASP.NET Core bilgisi üst seviye taşınır; Redis, Dapper, Docker, MongoDB, PostgreSQL, MSSQL, SQLite, Identity Server, API Gateway (Ocelot), SignalR, JWT tabanlı authentication/authorization, CQRS, Mediator, Repository pattern gibi modern altyapılar adım adım pratiklenir.

## Özellikler

- Mikroservis mimarisi
- Redis cache kullanımı
- Dapper ile lightweight veri erişimi
- Docker ile container ortamı
- MongoDB, PostgreSQL, MSSQL, SQLite veritabanı desteği
- Google Drive entegreli resim yükleme
- Identity Server ile kimlik doğrulama
- JWT / JWT Bearer authentication
- API Gateway (Ocelot)
- Swagger & Postman ile API keşfi
- Onion Architecture
- CQRS & Mediator deseni
- Repository pattern
- SignalR ile gerçek zamanlı iletişim
- Ajax & API consume senaryoları
- Rol bazlı yetkilendirme (Admin / Giriş yapan / Misafir)

## Mimari

Bu proje, her sorunun ve modülün ayrı mikroservisler olarak tutulduğu, temiz katmanlı (Onion) bir yapı kullanır. 
Her servis:
- Kendi veri katmanına sahip olabilir (farklı DB’ler)
- Kendi sorgu/komut ayrımını CQRS ile yapar
- Mediator üzerinden decoupled iletişim kurar

API Gateway üzerinden yönlendirme ve yetkilendirme sağlanır. Kimlik doğrulama Identity Server ile merkezi olur.

## Teknoloji Yığını

- **Backend:** ASP.NET Core
- **Authentication:** Identity Server, JWT (Bearer)
- **Cache:** Redis
- **ORM / Data Access:** Dapper
- **Veritabanları:** PostgreSQL, MSSQL, SQLite, MongoDB
- **API Gateway:** Ocelot
- **Real-time:** SignalR
- **Design Patterns:** Onion Architecture, CQRS, Mediator, Repository
- **Deployment/Container:** Docker
- **Dokümantasyon/Test:** Swagger, Postman
- **Dosya Yükleme:** Google Drive API entegrasyonu

## Gereksinimler

- .NET SDK (örneğin .NET 8+)
- Docker & Docker Compose
- Redis çalışır durumda
- PostgreSQL / MSSQL / MongoDB (docker ile sağlanabilir)
- Identity Server konfigürasyonu
- Google Drive API credentials (fotoğraf yükleme için)
- Temel ASP.NET Core bilgisi (zorunlu)


