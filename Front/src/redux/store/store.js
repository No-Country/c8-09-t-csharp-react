import { applyMiddleware, createStore } from 'redux';
import {composeWithDevTools} from "redux-devtools-extension"
import rootReducer from "../reducer/index.js";
import thunk from "redux-thunk"

export const store = createStore(
    rootReducer, 
    composeWithDevTools(applyMiddleware(thunk))
  );

  export default store;
