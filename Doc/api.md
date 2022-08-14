# Buber Dinner API

Table of Contracts(up to date)

- [Buber Dinner API](#buber-dinner-api)
  - [Authentication](#authentication)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Authentication

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
  "firstName": "Robiul",
  "lastName": "Hassan",
  "email": "victorshakil9102@gmail.com",
  "password": "Shakil123!*"
}
```

#### Register Response

```js
200 ok
```

```json
{
  "id": "f69bfb9d-2758-41da-bda0-7b5d0be60f7d",
  "firstName": "Robiul",
  "lastName": "Hassan",
  "email": "victorshakil9102@gmail.com",
  "token": "eyJhbGciO...adQssw5c"
}
```

### Login

```js
POST {{host}}/auth/login
```

#### Login Request

```json
{
  "email": "victorshakil9102@gmail.com",
  "password": "Shakil123!*"
}
```

#### Login Response

```js
200 ok
```

```json
{
  "id": "f69bfb9d-2758-41da-bda0-7b5d0be60f7d",
  "firstName": "Robiul",
  "lastName": "Hassan",
  "email": "victorshakil9102@gmail.com",
  "token": "eyJhbGciO...adQssw5c"
}
```
