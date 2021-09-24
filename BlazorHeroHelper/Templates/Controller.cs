﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHeroHelper.Templates
{
    public class Controller
    {
        public const string TemplateCode = @"using $_ADD_EDIT_COMMAND_NAMESPACE_$;
using $_DELETE_COMMAND_NAMESPACE_$;
using $_GET_ALL_PAGED_NAMESPACE_$;
using $_SHARED_CONST_PERMISSION_NAMESPACE_$;
using $_SERVER_CONTROLLER_NAMESPACE_$;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace $_NAMESPACE_$
{
    public class $_ENTITY_$sController : BaseApiController<$_ENTITY_$sController>
    {
        /// <summary>
        /// Get All $_ENTITY_$s
        /// </summary>
        /// <param name=""pageNumber""></param>
        /// <param name=""pageSize""></param>
        /// <param name=""searchString""></param>
        /// <param name=""orderBy""></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.$_ENTITY_$s.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize, string searchString, string orderBy = null)
        {
            var products = await _mediator.Send(new GetAll$_ENTITY_$sQuery(pageNumber, pageSize, searchString, orderBy));
            return Ok(products);
        }

        /// <summary>
        /// Add/Edit a $_ENTITY_$
        /// </summary>
        /// <param name=""command""></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.$_ENTITY_$s.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(AddEdit$_ENTITY_$Command command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Delete a $_ENTITY_$
        /// </summary>
        /// <param name=""id""></param>
        /// <returns>Status 200 OK response</returns>
        [Authorize(Policy = Permissions.$_ENTITY_$s.Delete)]
        [HttpDelete(""{id}"")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new Delete$_ENTITY_$Command { Id = id }));
        }
    }
}

";
    }
}