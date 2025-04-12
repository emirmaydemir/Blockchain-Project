using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbrsMarmara.Models
{
    public class BlockchainModel
    {
        public IList<BlockModel> Chain = new List<BlockModel>();
        public void InitializeChain()
        {
            Chain = new List<BlockModel>();
            AddGenesisBlock();
        }
        public void AddGenesisBlock()
        {
            Chain.Add(CreateGenesisBlock());
        }
        private BlockModel CreateGenesisBlock()
        {
            BlockModel block = new BlockModel(DateTime.Now, null, "0");
            return block;
        }
        public BlockModel GetLatestBlock()
        {
            return Chain[Chain.Count - 1];
        }
        public void AddBlock(BlockModel block)
        {
            BlockModel latestBlock = GetLatestBlock();
            block.id = latestBlock.id + 1;
            block.PreviousHash = latestBlock.Hash_;
            block.Hash_ = block.CreateHash();
            Chain.Add(block);
        }
        public bool IsValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                BlockModel currentBlock = Chain[i];
                BlockModel prevBlock = Chain[i - 1];

                if (currentBlock.Hash_ != currentBlock.CreateHash())
                {
                    return false;
                }

                if (currentBlock.PreviousHash != prevBlock.Hash_)
                {
                    return false;
                }

            }
            return true;
        }
    }
}
