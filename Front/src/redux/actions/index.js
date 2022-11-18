import axios from 'axios'

export function createUser(payload){
    return async function(dispatch){
        const response = await axios.post("https://cohorteapi.azurewebsites.net/api/Authenticate/Register", payload)
    }
}

