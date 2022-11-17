import { applyMiddleware, createStore } from 'redux';
import {composeWithDevTools} from "redux-devtools-extension"
import rootReducer from "../Reducer/index.js";
import thunk from "redux-thunk"

export const store = createStore(
    rootReducer, 
    composeWithDevTools(applyMiddleware(thunk))
  );

  export default store;