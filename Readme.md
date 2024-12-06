# UrlsMania

Este proyecto es una aplicación desarrollada en C# que permite acortar URLs largas y generarlas en un formato más manejable. Además, proporciona funcionalidades para redirigir las URLs cortas a sus destinos originales y realizar seguimiento de clics.

---

## Características Principales

- **Acortar URLs:** Genera enlaces cortos para URLs largas.
- **Redirección:** Al visitar una URL corta, el usuario es redirigido automáticamente a la URL original.

---

## Tecnologías Utilizadas

![Dotnet](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Redis](https://img.shields.io/badge/redis-%23DD0031.svg?&style=for-the-badge&logo=redis&logoColor=white)

---

## Requisitos Previos

1. **Dotnet Sdk 9**
2. **Administrador de contenedores(podman o docker)**

---

## Instalación y Arranque



## Uso de la Aplicación

1. Ingresa una URL larga en el campo de texto principal.
2. Haz clic en el botón "Acortar URL".
3. Copia y comparte el enlace corto generado.

---

## Despliegue

1. Publica la aplicación:

   ```bash
   dotnet publish -c Release -o ./public
   ```

---

## Contribuciones

¡Las contribuciones son bienvenidas! Si encuentras algún problema o tienes una sugerencia para mejorar el proyecto:

1. Crea un *issue* en este repositorio.
2. Haz un *fork* del proyecto y crea una nueva rama para tus cambios.
3. Envía un *pull request* para su revisión.

---

## Licencia

Este proyecto está bajo la licencia [MIT](LICENSE), lo que significa que puedes usarlo y modificarlo libremente, siempre que se otorgue crédito al autor original.