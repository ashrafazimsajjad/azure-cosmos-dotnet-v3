﻿//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Azure.Cosmos
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Operations for reading, replacing, or deleting a specific, existing cosmosContainer by id.
    /// 
    /// <see cref="CosmosContainers"/> for creating new containers, and reading/querying all containers;
    /// </summary>
    /// <remarks>
    ///  Note: all these operations make calls against a fixed budget.
    ///  You should design your system such that these calls scale sub linearly with your application.
    ///  For instance, do not call `cosmosContainer(id).read()` before every single `item.read()` call, to ensure the cosmosContainer exists;
    ///  do this once on application start up.
    /// </remarks>
    public abstract partial class CosmosContainer
    {
        /// <summary>
        /// The Id of the Cosmos container
        /// </summary>
        public abstract string Id { get; }

        /// <summary>
        /// Returns the parent database reference
        /// </summary>
        public abstract CosmosDatabase Database { get; }

        /// <summary>
        /// Operations for creating new items, and reading/querying all items
        /// </summary>
        /// <example>
        /// <code language="c#">
        /// <![CDATA[
        /// ItemResponse<MyCustomObject> response = await this.container.Items.CreateItemAsync<MyCustomObject>(user1);
        /// ]]>
        /// </code>
        /// </example>
        public abstract CosmosItems Items { get; }

        /// <summary>
        /// Operations for creating, reading/querying all stored procedures
        /// </summary>
        /// <example>
        /// <code language="c#">
        /// <![CDATA[
        /// CosmosStoredProcedureSettings settings = new CosmosStoredProcedureSettings
        ///{
        ///    Id = "testSProcId",
        ///    Body = "function() { { var x = 42; } }"
        ///};
        ///
        /// StoredProcedureResponse response = await cosmosContainer.StoredProcedures.CreateStoredProcedureAsync(settings);
        /// ]]>
        /// </code>
        /// </example>
        public abstract CosmosStoredProcedures StoredProcedures { get; }

        /// <summary>
        /// Reads a <see cref="CosmosContainerSettings"/> from the Azure Cosmos service as an asynchronous operation.
        /// </summary>
        /// <param name="requestOptions">(Optional) The options for the container request <see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">(Optional) <see cref="CancellationToken"/> representing request cancellation.</param>
        /// <returns>
        /// A <see cref="Task"/> containing a <see cref="ContainerResponse"/> which wraps a <see cref="CosmosContainerSettings"/> containing the read resource record.
        /// </returns>
        /// <exception cref="CosmosException">This exception can encapsulate many different types of errors. To determine the specific error always look at the StatusCode property. Some common codes you may get when creating a Document are:
        /// <list type="table">
        ///     <listheader>
        ///         <term>StatusCode</term><description>Reason for exception</description>
        ///     </listheader>
        ///     <item>
        ///         <term>404</term><description>NotFound - This means the resource you tried to read did not exist.</description>
        ///     </item>
        ///     <item>
        ///         <term>429</term><description>TooManyRequests - This means you have exceeded the number of request units per second. Consult the DocumentClientException.RetryAfter value to see how long you should wait before retrying this operation.</description>
        ///     </item>
        /// </list>
        /// </exception>
        /// <example>
        /// <code language="c#">
        /// <![CDATA[
        /// CosmosContainer cosmosContainer = this.database.Containers["containerId"];
        /// CosmosContainerSettings settings = cosmosContainer.ReadAsync();
        /// ]]>
        /// </code>
        /// </example>
        public abstract Task<ContainerResponse> ReadAsync(
            ContainerRequestOptions requestOptions = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Replace a <see cref="CosmosContainerSettings"/> from the Azure Cosmos service as an asynchronous operation.
        /// </summary>
        /// <param name="containerSettings">The <see cref="CosmosContainerSettings"/> object.</param>
        /// <param name="requestOptions">(Optional) The options for the container request <see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">(Optional) <see cref="CancellationToken"/> representing request cancellation.</param>
        /// <returns>
        /// A <see cref="Task"/> containing a <see cref="ContainerResponse"/> which wraps a <see cref="CosmosContainerSettings"/> containing the replace resource record.
        /// </returns>
        /// <exception cref="CosmosException">This exception can encapsulate many different types of errors. To determine the specific error always look at the StatusCode property. Some common codes you may get when creating a Document are:
        /// <list type="table">
        ///     <listheader>
        ///         <term>StatusCode</term><description>Reason for exception</description>
        ///     </listheader>
        ///     <item>
        ///         <term>404</term><description>NotFound - This means the resource you tried to read did not exist.</description>
        ///     </item>
        ///     <item>
        ///         <term>429</term><description>TooManyRequests - This means you have exceeded the number of request units per second. Consult the DocumentClientException.RetryAfter value to see how long you should wait before retrying this operation.</description>
        ///     </item>
        /// </list>
        /// </exception>
        /// <example>
        /// Update the cosmosContainer to disable automatic indexing
        /// <code language="c#">
        /// <![CDATA[
        /// ContainerSettings setting = containerReadResponse;
        /// setting.IndexingPolicy.Automatic = false;
        /// ContainerResponse response = cosmosContainer.ReplaceAsync(setting);
        /// ContainerSettings settings = response;
        /// ]]>
        /// </code>
        /// </example>
        public abstract Task<ContainerResponse> ReplaceAsync(
            CosmosContainerSettings containerSettings,
            ContainerRequestOptions requestOptions = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Delete a <see cref="CosmosContainerSettings"/> from the Azure Cosmos DB service as an asynchronous operation.
        /// </summary>
        /// <param name="requestOptions">(Optional) The options for the container request <see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">(Optional) <see cref="CancellationToken"/> representing request cancellation.</param>
        /// <returns>A <see cref="Task"/> containing a <see cref="ContainerResponse"/> which will contain information about the request issued.</returns>
        /// <exception cref="CosmosException">This exception can encapsulate many different types of errors. To determine the specific error always look at the StatusCode property. Some common codes you may get when creating a Document are:
        /// <list type="table">
        ///     <listheader>
        ///         <term>StatusCode</term><description>Reason for exception</description>
        ///     </listheader>
        ///     <item>
        ///         <term>404</term><description>NotFound - This means the resource you tried to delete did not exist.</description>
        ///     </item>
        /// </list>
        /// </exception>
        /// <example>
        /// <code language="c#">
        /// <![CDATA[
        /// CosmosContainer cosmosContainer = this.database.Containers["containerId"];
        /// ContainerResponse response = cosmosContainer.DeleteAsync();
        ///]]>
        /// </code>
        /// </example>
        public abstract Task<ContainerResponse> DeleteAsync(
            ContainerRequestOptions requestOptions = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets throughput provisioned for a container in measurement of Requests-per-Unit in the Azure Cosmos service.
        /// </summary>
        /// <param name="cancellationToken">(Optional) <see cref="CancellationToken"/> representing request cancellation.</param>
        /// <value>
        /// The provisioned throughput for this database.
        /// </value>
        /// <remarks>
        /// <para>
        /// Refer to http://azure.microsoft.com/documentation/articles/documentdb-performance-levels/ for details on provision offer throughput.
        /// </para>
        /// </remarks>
        /// <example>
        /// The following example shows how to get the throughput.
        /// <code language="c#">
        /// <![CDATA[
        /// int? throughput = await this.cosmosContainer.ReadProvisionedThroughputAsync();
        /// ]]>
        /// </code>
        /// </example>
        public abstract Task<int?> ReadProvisionedThroughputAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Sets throughput provisioned for a container in measurement of Requests-per-Unit in the Azure Cosmos service.
        /// </summary>
        /// <param name="throughput">The cosmos container throughput</param>
        /// <param name="cancellationToken">(Optional) <see cref="CancellationToken"/> representing request cancellation.</param>
        /// <value>
        /// The provisioned throughput for this database.
        /// </value>
        /// <remarks>
        /// <para>
        /// Refer to http://azure.microsoft.com/documentation/articles/documentdb-performance-levels/ for details on provision offer throughput.
        /// </para>
        /// </remarks>
        /// <example>
        /// The following example shows how to get the throughput.
        /// <code language="c#">
        /// <![CDATA[
        /// int? throughput = await this.cosmosContainer.ReplaceProvisionedThroughputAsync(400);
        /// ]]>
        /// </code>
        /// </example>
        public abstract Task ReplaceProvisionedThroughputAsync(
            int throughput,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Reads a <see cref="CosmosContainerSettings"/> from the Azure Cosmos service as an asynchronous operation.
        /// </summary>
        /// <param name="requestOptions">(Optional) The options for the container request <see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">(Optional) <see cref="CancellationToken"/> representing request cancellation.</param>
        /// <returns>
        /// A <see cref="Task"/> containing a <see cref="CosmosResponseMessage"/> containing the read resource record.
        /// </returns>
        public abstract Task<CosmosResponseMessage> ReadStreamAsync(
            ContainerRequestOptions requestOptions = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Replace a <see cref="CosmosContainerSettings"/> from the Azure Cosmos service as an asynchronous operation.
        /// </summary>
        /// <param name="streamPayload">The <see cref="Stream"/> object.</param>
        /// <param name="requestOptions">(Optional) The options for the container request <see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">(Optional) <see cref="CancellationToken"/> representing request cancellation.</param>
        /// <returns>
        /// A <see cref="Task"/> containing a <see cref="CosmosResponseMessage"/> containing the replace resource record.
        /// </returns>
        public abstract Task<CosmosResponseMessage> ReplaceStreamAsync(
            Stream streamPayload,
            ContainerRequestOptions requestOptions = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Delete a <see cref="CosmosContainerSettings"/> from the Azure Cosmos DB service as an asynchronous operation.
        /// </summary>
        /// <param name="requestOptions">(Optional) The options for the container request <see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">(Optional) <see cref="CancellationToken"/> representing request cancellation.</param>
        /// <returns>A <see cref="Task"/> containing a <see cref="CosmosResponseMessage"/> which will contain information about the request issued.</returns>
        public abstract Task<CosmosResponseMessage> DeleteStreamAsync(
            ContainerRequestOptions requestOptions = null,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}