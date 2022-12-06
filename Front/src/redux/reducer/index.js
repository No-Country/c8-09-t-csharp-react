import jwt_decode from "jwt-decode";
import { useEffect } from "react";
import { useDispatch } from "react-redux";

const singleUserEmpty = {
    id: 0,
    name: "",
    email: "",
    rol: "",
}

const initialState = {
    allEvents: [],
    singleUser: localStorage.getItem('user') ? JSON.parse(localStorage.getItem('user')) : singleUserEmpty,
    userloginData: [],
    isLogged: null,
<<<<<<< HEAD
    allEventsCopy: []
=======
    forgotPasswordToken: []
>>>>>>> 0bca1c78f094f3dabfa5b10149e09bbf437dfefe
}

function rootReducer(state = initialState, action) {
    switch (action.type) {
        case "CREATE_USER":
            return {
                ...state
            }
        case "GET_EVENTS":
            return{
                ...state,
                allEvents: action.payload,
                allEventsCopy: action.payload
                }
        case "CLEAR_USER":
            return {
                ...state,
                singleUser: singleUserEmpty
            }

        case "LOGIN_USER":
            const initialData = action.payload
            const decode = jwt_decode(initialData.token)
            localStorage.setItem("user", JSON.stringify(decode))
            return{
                ...state,
                userloginData: decode
            }
        case "CHECK_LOCAL_STORAGE":
            return {
                ...state,
                isLogged: action.payload
            }

        case "FILTER_BY_GENRES":
            const getGenres = state.allEvents
            const filtering = action.payload === "Todos" ? state.allEvents :
            state.allEvents.data.filter(e => {
                if(e.category.name){
                    if(e.category.name == action.payload){
                        return e
                    }
                }
            })
            return{
                ...state,
                allEvents: getGenres,
                allEventsCopy: filtering
            }

        case "FORGOT_PASSWORD":
            const forgotPassToken = action.payload
            localStorage.setItem("forgotPasswordToken", JSON.stringify(forgotPassToken))
            return {
                ...state,
                forgotPasswordToken: action.payload
            }   

        case "RESET_PASSWORD":
            return{
                ...state
            }
            
        default: return state;
    }
}

export default rootReducer;
