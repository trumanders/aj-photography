import { useEffect, useState } from 'react'
import { fetchPhotosByPageCategory } from '../api';
import './Home.css';
import HomePageCategoryPhotos from '../components/HomePageCategoryPhotos';

function Home() {
    const [homePagePhotos, setHomePagePhotos] = useState<any[]>([]);

    useEffect(() => {
        fetchPhotosByPageCategory('HomePage')
            .then(setHomePagePhotos)
            .catch(console.error);
    }, []);

    return (
        <>
            <div className="images-container">
                <div className="images-container">
                    <HomePageCategoryPhotos categoryHeader="PORTRÄTT" photoCategory="Portrait" photos={homePagePhotos} />
                    <HomePageCategoryPhotos categoryHeader="NATUR" photoCategory="Nature" photos={homePagePhotos} />
                    <HomePageCategoryPhotos categoryHeader="BRÖLLOP" photoCategory="Wedding" photos={homePagePhotos} />
                    <HomePageCategoryPhotos categoryHeader="FAMILJ" photoCategory="Family" photos={homePagePhotos} />
                </div>
            </div>
        </>
    )
}

export default Home