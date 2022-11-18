import style from './Buttons.module.css'

const ButtonLeft = ({ action }) => {
	return (
		<button className={style.buttons} onClick={action}>
			<svg
				width='15'
				height='24'
				viewBox='0 0 15 24'
				fill='none'
				xmlns='http://www.w3.org/2000/svg'
			>
				<path
					d='M12 24L0 12L12 0L14.8 2.8L5.6 12L14.8 21.2L12 24Z'
					fill='#1F1F1F'
				/>
			</svg>
		</button>
	)
}

export default ButtonLeft
