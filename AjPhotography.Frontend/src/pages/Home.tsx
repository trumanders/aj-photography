// import { useState } from 'react'
import './Home.css';

// const images = [
//     '/1.jpg',
//     '/2.jpg',
//     '/3.jpg',
//     '/4.jpg',
//     '/5.jpg',
//     '/6.jpg',
//     '/7.jpg',
//     '/8.jpg',
// ]

function Home() {
    // const [centerIndex, setCenterIndex] = useState<number>(2)
    
    // const prev = () => {
    //     setCenterIndex((i: number) => (i === 0 ? images.length - 1 : i - 1))
    // }
    
    // const next = () => {
    //     setCenterIndex((i: number) => (i === images.length - 1 ? 0 : i + 1))
    // }

    return (
        <>
            <div className="images-container">
                <div className="category-container">
                    <p>PORTRÄTT</p>
                </div>
                <div className="category-container">
                    <p>NATUR</p>
                </div>                
                <div className="category-container">
                    <p>BRÖLLOP</p>
                </div>
            </div>
        </>
    )
}

export default Home