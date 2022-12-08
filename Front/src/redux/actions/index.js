import axios from 'axios'
import { isUserLogged } from '../../utils/validations'

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
        const response = await axios.get("https://cohorteapi.azurewebsites.net/api/Events")
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

export function checkLocalStorage(payload){
    return async function(dispatch){
        try{

            let result = isUserLogged()

            return dispatch({
                type: "CHECK_LOCAL_STORAGE",
                payload: result
            })
        } catch(error){
            return error
        }
    }
}

export function filterByGenres(payload){
    return{
        type: "FILTER_BY_GENRES",
        payload
    }
}

export function forgotPassword(payload){
    return async function(dispatch){
        try {
            const response = await axios.post(`https://cohorteapi.azurewebsites.net/api/Authenticate/ForgotPassword?email=${payload}`, payload)

            dispatch({
                type: "FORGOT_PASSWORD",
                payload: response.data
            })

            console.log(response.status)
            return response.status
            
        } catch(error){
            return error
        }
        
    }
}

export function resetPassword(payload){
    return async function(dispatch){
        try{    
            const response = await axios.post("https://cohorteapi.azurewebsites.net/api/Authenticate/ResetPassword", payload)

            dispatch({
                type: "RESET_PASSWORD",
                payload: response.data
            })

            console.log(response.status)
            return response.status

        } catch(error){
            return error
        }
    }
}

export function eventDetails(id){
    return async function(dispatch){
        const response = await axios.get(`https://cohorteapi.azurewebsites.net/api/Events/${id}`)
        dispatch({
            type: "GET_AN_EVENT",
            payload: response.data
        })

        return response.data
    }
}
