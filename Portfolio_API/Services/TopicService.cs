﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Portfolio_API;

public class TopicService
{
    private readonly ApplicationDatabaseContext _db;
    private readonly IMapper _mapper;

    public TopicService(ApplicationDatabaseContext context, IMapper mapper)
    {
        _db = context;
        _mapper = mapper;
    }

    public async Task<List<ReadTopicDto>> GetAllTopics()
    {
        List<TopicModel>? topics = await _db.Topics.ToListAsync();
        List<ReadTopicDto> listTopics = _mapper.Map<List<ReadTopicDto>>(topics);

        return listTopics ?? new List<ReadTopicDto>();
    }

    public async Task<ReadTopicDto> GetTopicById(int id)
    {
        TopicModel? topic = await _db.Topics.FirstOrDefaultAsync(x => x.Id == id);
        return _mapper.Map<ReadTopicDto>(topic) ?? new ReadTopicDto();
    }

    public async Task<ReadTopicDto> CreateTopic(CreateLangDto createLangDto)
    {
        var topic = _mapper.Map<TopicModel>(createLangDto);
        _db.Topics.Add(topic);
        await _db.SaveChangesAsync();
        return _mapper.Map<ReadTopicDto>(topic);
    }

    public async Task<ReadTopicDto?> UpdateTopic(int id, UpdateLangDto updateLangDto)
    {
        var topic = await _db.Topics.FirstOrDefaultAsync(x => x.Id == id);
        if (topic == null) return null;
        _mapper.Map(updateLangDto, topic);
        await _db.SaveChangesAsync();
        return _mapper.Map<ReadTopicDto>(topic);
    }

    public async Task<bool> DeleteTopic(int id)
    {
        var topic = await _db.Topics.FirstOrDefaultAsync(x => x.Id == id);
        if (topic == null) return false;
        _db.Topics.Remove(topic);
        await _db.SaveChangesAsync();
        return true;
    }
}