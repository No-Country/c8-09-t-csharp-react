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

