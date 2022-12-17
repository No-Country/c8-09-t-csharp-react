import './App.css'
import { Routes, Route } from 'react-router-dom'

import Home from './pages/home/Home'
import Login from './pages/login/login'
import Register from './pages/register/register'
import ForgotPassword from './pages/forgotPassword/forgotPassword'
import ResetPassword from './pages/resetPassword/resetPassword'
import PrePurchase from './components/prePurchase/prePurchase'
import { AuthGuard } from './guards/AuthGuard'
import { AuthRolesGuard } from './guards/AuthRolesGuard'
import { isUserAdmin, isUserLogged } from './utils/validations'
import Error from "./pages/error/error"
import Event from './pages/event/event'
import Catalogo from './pages/catalogo/catalogo'
import Checkout from './components/Checkout/Checkout'

function App() {

	return (
		<Routes>
			<Route index element={<Home />} />
			<Route element={<PrePurchase />} exact path={'/prePurchase/'} />
			<Route element={<Checkout />} exact path={'/checkout'}/>
			<Route element={<ForgotPassword />} path={'/forgotPassword'} />
			<Route element={<ResetPassword />} exact path={'/resetpassword'} />
			<Route element={<Event />} path={'/event/:id'} />
			<Route element={<Catalogo/>} path={'/catalogo'}/>
			<Route
				element={
					<AuthGuard redirectPath={'/account'} isAllowed={!isUserLogged()} />
				}
			>
				<Route element={<Register />} path={'/register'} />
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
					{/* <Route element={<Error/>} path={'*'} /> */}
				</Route>
			</Route>
			<Route element={<Error/>} path={'*'} />
		</Routes>
	)
}

export default App