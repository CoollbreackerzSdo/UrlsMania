# UrlsMania

Este proyecto es una aplicación desarrollada en C# que permite acortar URLs largas y generarlas en un formato más manejable. Además, proporciona funcionalidades para redirigir las URLs cortas a sus destinos originales y realizar seguimiento de clics.

---

## Características Principales

- **Acortar URLs:** Genera enlaces cortos para URLs largas.
- **Redirección:** Al visitar una URL corta, el usuario es redirigido automáticamente a la URL original.

---

## Tecnologías Utilizadas

![Dotnet](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Postgres](https://img.shields.io/badge/postgres-%23DD0031.svg?&style=for-the-badge&logo=postgrest&logoColor=white)

---

## Requisitos Previos

1. **Dotnet Sdk 9**
2. **Administrador de contenedores(podman o docker)**

---

##  Arranque

```
    dotnet workload install aspire
    dotnet wacht -q -p .\UrlsMania.AppHost\
```

---

## Licencia

Este proyecto está bajo la licencia [MIT](LICENSE), lo que significa que puedes usarlo y modificarlo libremente, siempre que se otorgue crédito al autor original.