# Weather Forecast API with JWT Authentication

This repository contains an ASP.NET Core Web API project that demonstrates the use of JWT (JSON Web Tokens) for securing endpoints and implementing role-based access control.

## Overview

This API provides weather forecast data and showcases how to secure endpoints using JWT authentication. It restricts access to certain routes based on user roles, making it a practical example of implementing authentication and authorization in a .NET environment.

## What is JWT?

**JSON Web Tokens (JWT)** are an open, industry-standard method (RFC 7519) for securely transmitting information between parties as a JSON object. JWTs are compact, URL-safe, and can be verified and trusted because they are digitally signed using a secret key.

### Key Features of JWT:

- **Self-Contained**: JWT contains all the necessary information about the user, reducing the need for repeated database queries.
- **Secure**: JWT can be signed with a secret or a public/private key pair using algorithms like HMAC SHA256, ensuring the integrity of the data.
- **Stateless**: JWT authentication is stateless; no session is stored on the server, making it easy to scale.

## How JWT Works in This API

1. **Token Generation**: When a user logs in, a JWT token is generated containing the user's claims, such as their ID, email, and roles.
2. **Access Control**: The API uses the `[Authorize]` attribute to protect endpoints, allowing access only if the request includes a valid token.
3. **Role-Based Authorization**: The API checks the user's role in the token to determine access to specific routes, ensuring that only authorized users (e.g., Admins) can perform certain actions.

## Key Benefits

- **Enhanced Security**: JWT helps ensure that only authenticated users can access protected resources.
- **Scalable**: As the application grows, JWT provides a scalable solution for managing user authentication without storing session state on the server.
- **Easy to Integrate**: JWT is widely supported across various platforms, making it easy to integrate with other applications and services.

## Getting Started

To run this API, ensure you have the .NET 6 SDK installed, configure your JWT settings in the `appsettings.json`, and run the application. Ensure to generate and pass a valid JWT token when accessing protected endpoints.

## Contribution

Contributions are welcome! Please feel free to fork the repository, make changes, and submit a pull request.
