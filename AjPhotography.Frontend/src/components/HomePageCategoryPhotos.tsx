import React from 'react';

interface Photo {
  url: string;
  photoCategory: string;
}

interface Props {
  categoryHeader: string;
  photoCategory: string;
  photos: Photo[];
}

const HomePageCategoryPhotos: React.FC<Props> = ({ categoryHeader, photoCategory, photos }) => {
  const filteredPhotos = photos.filter(photo => photo.photoCategory === photoCategory);

  return (
    <div className="category-container">
      <p>{categoryHeader}</p>
      <div className="category-photos-row">
        {filteredPhotos.map((photo, index) => (
          <img key={index} src={photo.url} alt={`${index}`} />
        ))}
      </div>
    </div>
  );
};

export default HomePageCategoryPhotos;
