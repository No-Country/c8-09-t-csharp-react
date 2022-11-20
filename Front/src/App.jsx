import './App.css'
import { Routes, Route } from 'react-router-dom'

import Home from './pages/home/Home'
import Login from './pages/login/login'
import Register from './pages/register/register'
import ForgotPassword from './pages/forgotPassword/forgotPassword'
import { AuthGuard } from './guards/AuthGuard'
import { AuthRolesGuard } from './guards/AuthRolesGuard'
import { isUserAdmin, isUserLogged } from './utils/validations'

function App() {
	return (
		<Routes>
			<Route index element={<Home />} />
			<Route element={<Register />} path={'/register'} />
			<Route element={<ForgotPassword />} path={'/forgotPassword'} />
			<Route
				element={
					<AuthGuard redirectPath={'/account'} isAllowed={!isUserLogged()} />
				}
			>
				<Route element={<Login />} exact path={'/login'} />
			</Route>
			<Route element={<AuthGuard isAllowed={isUserLogged()} />}>
				<Route element={<div>Account</div>} exact path={'/account/*'}>
					{/* aca van la sub ruta de account*/}
				</Route>
				<Route element={<AuthRolesGuard isAllowed={isUserAdmin()} />}>
					<Route element={<div>Admin</div>} exact path={'/admin/*'}>
						{/* aca van la sub ruta de account*/}
					</Route>
					<Route element={<div>Not Found 404</div>} path={'*'} />
				</Route>
			</Route>
			<Route element={<div>Not Found 404</div>} path={'*'} />
		</Routes>
	)
}

export default App
