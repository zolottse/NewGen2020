﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallery.DAL.Model;
using Gallery.DAL.Repositories.Interfaces;

namespace Gallery.DAL.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private readonly GalleryContext _ctx;

        public MediaRepository(GalleryContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }


        //
        // Media
        //
        public async Task RegisterMediaToDataBaseAsync(Media media)
        {
            _ctx.Media.Add(media);
            await _ctx.SaveChangesAsync();
        }

        public async Task ChangeDeleteStatusAsync(string name, bool status)
        {
            var media = await _ctx.Media.FirstOrDefaultAsync(p => p.Name == name);
            if (media != null)
            {
                media.IsDeleted = status;
            }
            await _ctx.SaveChangesAsync();
        }

        public async Task<Media> GetMediaByNameAsync(string name)
        {
            return await _ctx.Media.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<bool> IsMediaExistAsync(string name)
        {
            return await _ctx.Media.AnyAsync(p => p.Name == name);
        }


        //
        // TempMedia
        //
        public async Task RegisterTempMediaToDataBaseAsync(TempMedia tempMedia)
        {
            _ctx.TempMedia.Add(tempMedia);
            await _ctx.SaveChangesAsync();
        }

        public async Task ChangeTempMediaAsync(TempMedia oldTempMedia, TempMedia newTempMedia)
        {
            oldTempMedia = newTempMedia;
            _ctx.Entry(oldTempMedia).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }

        public async Task<TempMedia> GetTempMediaByNameAndLoadingStatusAsync(string name, bool loadingStatus)
        {
            return await _ctx.TempMedia.FirstOrDefaultAsync(p => p.UniqName == name
                                                                 && p.IsLoading == loadingStatus);
        }

        public async Task<bool> IsTempMediaExistByNameAndLoadingStatusAsync(string name, bool loadingStatus)
        {
            return await _ctx.TempMedia.AnyAsync(p => p.UniqName == name
                                                      && p.IsLoading == loadingStatus);
        }


        //
        // MediaType
        //
        public async Task RegisterMediaTypeToDataBaseAsync(MediaType type)
        {
            _ctx.MediaType.Add(type);
            await _ctx.SaveChangesAsync();
        }

        public async Task<MediaType> GetMediaTypeByTypeAsync(string type)
        {
            return await _ctx.MediaType.FirstOrDefaultAsync(p => p.Type == type);
        }

        public async Task<bool> IsMediaTypeExistAsync(string type)
        {
            return await _ctx.MediaType.AnyAsync(p => p.Type == type);
        }


    }
}
