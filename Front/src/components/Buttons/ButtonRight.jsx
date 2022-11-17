import style from './Buttons.module.css'

const ButtonRight = ({ action }) => {
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
					d='M2.8 24L0 21.2L9.2 12L0 2.8L2.8 0L14.8 12L2.8 24Z'
					fill='#1F1F1F'
				/>
			</svg>
		</button>
	)
}

export default ButtonRight
