/* eslint-disable react/prop-types */
/* eslint-disable no-undef */
import { useEffect, useState } from 'react'
import ButtonLeft from '../Buttons/ButtonLeft'
import ButtonRight from './../Buttons/ButtonRight'
import style from './Comments.module.css'
import banner1 from './banner1.jpg'
import banner2 from './banner2.jpg'

const arrImg = [banner1, banner2]
const arrayComments = [{autor:"Maxi Martins",comment:"Gracias a Ticket Fan ahorro un montón de tiempo a la hora de comprar entradas para mis eventos favoritos..."},{autor:"María José",comment:"Nunca fue tan fácil encontrar entradas para mis eventos hasta que conocí Ticket Fan..."}]

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
					<ButtonLeft action={previous} />

					<div className={style.description}>
						<h3 className={style.comment} >
							{`" ${arrayComments[selectedIndex].comment} "`}
						</h3>
						<span className={style.descriptionName}>{arrayComments[selectedIndex].autor}</span>
					</div>

					<ButtonRight action={next} />
				</div>
			</div>
		</div>
	)
}

export default Comments
