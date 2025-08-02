import { useEffect, useState } from 'react'
import { fetchPhotosByCategory } from '../api';
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
    const [photos, setPhotos] = useState<any[]>([]);

    useEffect(() => {
        fetchPhotosByCategory('portraits')
            .then(setPhotos)
            .catch(console.error);
    }, []);

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
                    <div className="category-photos-row">
                        {photos.map((photo, index) => (
                            <img src={photo.imageUrl} alt={`Photo ${index + 1}`} />
                        ))}
                    </div>
                </div>
                <div className="category-container">
                    <p>NATUR</p>
                </div>                
                <div className="category-container">
                    <p>BRÖLLOP</p>
                </div>
                    <div className="category-container">
                    <p>FAMILJ</p>
                </div>
            </div>
        </>
    )
}

export default Home