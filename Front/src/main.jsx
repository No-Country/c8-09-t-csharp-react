import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App'
import './index.css'
import {BrowserRouter} from "react-router-dom"
import Nav from "./components/nav/Nav"

ReactDOM.createRoot(document.getElementById('root')).render(
    <BrowserRouter>
      <React.StrictMode>
        <Nav />
        <App/>
      </React.StrictMode>
    </BrowserRouter>
)
