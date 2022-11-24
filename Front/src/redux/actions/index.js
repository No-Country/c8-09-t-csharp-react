import axios from 'axios'

export function createUser(payload){
    return async function(dispatch){
        const response = await axios.post("https://cohorteapi.azurewebsites.net/api/Authenticate/Register", payload)
    }
}

export function getEvents(payload){
    return async function(dispatch){
        const response = await axios.get("https://635eb27203d2d4d47af47b8b.mockapi.io/Cohorte")
        return dispatch({
            type: "GET_EVENTS",
            payload: response,
        })
    }
}