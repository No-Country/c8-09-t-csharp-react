import './App.css'
import {Routes, Route} from "react-router-dom"

import Home from './pages/home/Home'
import Login from './pages/login/login'
import Register from './pages/register/register'
import ForgotPassword from './pages/forgotPassword/forgotPassword'



function App() {

	return (
		<Routes>
			{/* RUTAS PUBLICAS */}
			<Route element={<Home/>} path={"/"}/>
			<Route element={<Login />} exact path={"/login"} />
			<Route element={<Register />} path={"/register"} />
			<Route element={<ForgotPassword />} path={"/forgotPassword"} />

			{/* RUTAS PROTEGIDAS */}
			
		</Routes>

		
	)
}


export default App
