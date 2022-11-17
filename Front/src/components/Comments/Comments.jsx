/* eslint-disable react/prop-types */
/* eslint-disable no-undef */
import { useEffect, useState } from 'react'
import style from './Comments.module.css'
import banner1 from './banner1.jpg'
import banner2 from './banner2.jpg'

const arrImg = [banner1, banner2]

const ButtonLeft = () => (
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
)

const ButtonRight = () => (
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
)

const Comments = ({ images = arrImg, autoPlay = true, showButtons = true }) => {
	const [selectedIndex, setSelectedIndex] = useState(0)
	const [selectedImage, setSelectedImage] = useState(images[0])

	useEffect(() => {
		if (autoPlay || !showButtons) {
			const interval = setInterval(() => {
				selectNewImage(selectedIndex, images)
			}, 3000)
			return () => clearInterval(interval)
		}
	})

	const selectNewImage = (index, images, next = true) => {
		setTimeout(() => {
			const condition = next
				? selectedIndex < images.length - 1
				: selectedIndex > 0
			const nextIndex = next
				? condition
					? selectedIndex + 1
					: 0
				: condition
				? selectedIndex - 1
				: images.length - 1
			setSelectedImage(images[nextIndex])
			setSelectedIndex(nextIndex)
		}, 500)
	}

	const previous = () => {
		selectNewImage(selectedIndex, images, false)
	}

	const next = () => {
		selectNewImage(selectedIndex, images)
	}

	return (
		<div className={style.comments}>
			<img src={selectedImage} alt={'Banner'} />
			<div className={style.container}>
				<h3>Lo que opina la gente</h3>
				<div>
					<button className={style.containerButton} onClick={previous}>
						<ButtonLeft />
					</button>
					<div className={style.description}>
						<h3>
							{'"Lorem ipsum dolor sit amet consectetur adipisicing elit."'}
						</h3>
						<span className={style.descriptionName}>María José</span>
					</div>
					<button className={style.containerButton} onClick={next}>
						<ButtonRight />
					</button>
				</div>
			</div>
		</div>
	)
}

export default Comments
