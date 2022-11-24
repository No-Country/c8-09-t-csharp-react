import axios from 'axios'

export function createUser(payload){
    return async function(dispatch){
       try{
        const APIresponse = await axios.post("https://cohorteapi.azurewebsites.net/api/Authenticate/Register", payload)
        // console.log(APIresponse.status)
        return APIresponse.status
        
       } catch(error){
            let APIError = error.response.data.message
            // console.log(APIError)
            return APIError
       }
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

export function loginUser(payload){
    return async function(dispatch){

        try{
            const APIresponse = await axios.post("https://cohorteapi.azurewebsites.net/api/Authenticate/Login", payload)

            dispatch({
                type: "LOGIN_USER",
                payload: APIresponse.data
            })

            return APIresponse.status

        } catch(error){
            // return `Error ${error.response.status}: ${error.response.statusText}`
            return error
        }

    }
}
