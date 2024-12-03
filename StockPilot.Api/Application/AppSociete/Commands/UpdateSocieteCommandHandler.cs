using AutoMapper;
using MediatR;
using StockPilot.Domain.Entities;
using StockPilot.Domain.IRepositories;

namespace StockPilot.Api.Application.AppSociete.Commands
{
    public class UpdateSocieteCommandHandler : IRequestHandler<UpdateSocieteCommand, Response>
    {
        private readonly IGenericRepository<Societé> _societerepository;
        private readonly IMapper _mapper;

        public UpdateSocieteCommandHandler(IGenericRepository<Societé> societerepository, IMapper mapper)
        {
            _societerepository = societerepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateSocieteCommand request, CancellationToken cancellationToken)
        {
            var existingsociete = _societerepository.GetAll().FirstOrDefault(s => s.SocietéId == request.SocieteId);

            if (existingsociete == null) 
            {
                return new Response
                {
                    Success = false,
                    Message = "Societé not found."
                };
            }
            try
            {
                //var societe = _mapper.Map<Societé>(existingsociete);
                _mapper.Map(request,existingsociete);
                _societerepository.Update(existingsociete);
                return new Response
                {
                    Success = true,
                    Message = "societe updated successfuly",
                    SocieteId = request.SocieteId
                };
            }
            catch (Exception ex) 
            {
                return new Response
                {
                    Success = false,
                    Message = $"Error updating societe : {ex.Message}",
                };
            }
        }
    }
}
