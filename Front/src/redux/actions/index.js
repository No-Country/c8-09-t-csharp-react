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
