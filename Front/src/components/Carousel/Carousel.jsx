import { useState } from 'react'
import style from './Carousel.module.css'
import header from './header.jpg'
import header1 from './header1.jpg'
import header2 from './header2.jpg'
import { Link } from 'react-router-dom'
import ButtonLeft from '../Buttons/ButtonLeft'
import ButtonRight from '../Buttons/ButtonRight'

const Carousel = () => {
	const arrImg = [header, header1, header2]
	const [selectedIndex, setSelectedIndex] = useState(0)
	const [selectedImage, setSelectedImage] = useState(arrImg[0])

	const updateIndex = (next = false) => {
		const condition = next
			? selectedIndex < arrImg.length - 1
			: selectedIndex > 0
		const nextIndex = next
			? condition
				? selectedIndex + 1
				: 0
			: condition
			? selectedIndex - 1
			: arrImg.length - 1
		setSelectedImage(arrImg[nextIndex])
		setSelectedIndex(nextIndex)
	}

	const previous = () => {
		updateIndex()
	}

	const next = () => {
		updateIndex(true)
	}

	return (
		<div className={style.carousel}>
			<img className={style.header} src={selectedImage} alt={'Banner'} />
			<div className={style.container}>
				<ButtonLeft action={previous} />
				<div className={style.headerInfo}>
					<h1>{'Lorem ipsum dolor sit amet, consectetur.'}</h1>
					<Link to={'/'} className={style.headerButton}>
						Mas información
					</Link>
				</div>
				<ButtonRight action={next} />
			</div>
		</div>
	)
}

export default Carousel
