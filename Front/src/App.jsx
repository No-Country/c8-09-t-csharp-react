import './App.css'
import {Routes, Route} from "react-router-dom"

import Home from './pages/home/Home'
import Login from './pages/login/login'

function App() {

	return (
		<Routes>
			<Route element={<Home/>} path={"/"}/>
			<Route element={<Login />} path={"/login"} />
		</Routes>
	)
}

export default App
