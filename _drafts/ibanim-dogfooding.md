https://iban.im/graph

{
  getProfile(username: "guneysus") {
    ok
    error
    user {
      visible
      handle
      firstName
      lastName
      email
      bio
      createdAt
      handle
      avatar
      
    }
    iban {
      id
      text
      isPrivate
      handle
      password
    }
  }
}


{
  __schema {
    types {
      name
      description
    }
  }
}

{
  __schema {
    directives {
      name
      description
    }
  }
}